using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de regular el movimiento y los disparos de Blinky, estrechamente relacionados entre ellos. Versión teclado.
public class Blinky : MonoBehaviour
{

    // fields
    bool mirandoDerecha = true;     // Determina la dirección en la que está mirando Blinky, y por tanto en la que debe disparar.
    bool puedeAndar = true;         // Determina si Blinky puede moverse o no (por estar disparando).
    RaycastHit2D hit;

    // properties
    public Animator blinkyAnim;
    public GameObject masPuntos;
    public float tiempoCD;                  // Determina el tiempo de enfriamiento que tiene el disparo de Blinky.
    public float velocidadMovimiento;       // Determina la velocidad del movimiento de Blinky.
    public Puntuacion contador;             // Aquí debe instanciarse el contador de puntos para que se sumen los puntos conseguidos.

    private Transform m_dynamicTransform;
    private Transform DynamicTransform
    {
        get
        {
            if (m_dynamicTransform != null)
                return m_dynamicTransform;
            else
            {
                GameObject dynamicGameObject = GameObject.Find("_Dynamic");
                if (dynamicGameObject == null)
                    dynamicGameObject = new GameObject("_Dynamic");
                m_dynamicTransform = dynamicGameObject.transform;
                return m_dynamicTransform;
            }
        }
    }

    // methods
    void FixedUpdate()
    {

        // Al pulsar espacio, el personaje dispara si no está en cooldoown.
        Movimiento();
        if ((Input.GetKeyDown(KeyCode.Space)) && (puedeAndar == true))
        {
            StartCoroutine("Disparo");
        }

    }

    void LateUpdate()
    {

        // Si el personaje está disparando, se detiene su movimiento.
        if (puedeAndar == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    void Movimiento()
    {

        // Al pulsar A el personaje se mueve, siempre que pueda moverse en ese momento.
        if ((Input.GetKey(KeyCode.A)) && (puedeAndar == true))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
            mirandoDerecha = false;
            blinkyAnim.SetBool("MirandoDer", false);
            blinkyAnim.SetBool("Andando", true);
        }

        // Al soltar A, el personaje deja de moverse.
        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, GetComponent<Rigidbody2D>().velocity.y);
            blinkyAnim.SetBool("Andando", false);
        }

        // Al pulsar D el personaje se mueve, siempre que pueda moverse en ese momento.
        if ((Input.GetKey(KeyCode.D)) && (puedeAndar == true))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
            mirandoDerecha = true;
            blinkyAnim.SetBool("MirandoDer", true);
            blinkyAnim.SetBool("Andando", true);
        }

        // Al soltar D, el personaje deja de moverse.
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, GetComponent<Rigidbody2D>().velocity.y);
            blinkyAnim.SetBool("Andando", false);
        }


    }

    IEnumerator Disparo()
    {

        puedeAndar = false;
        blinkyAnim.SetBool("Disparo", true);
        // Si el personaje se haya mirando a la derecha, lanza un Raycast 45º en dirección a la derecha, de lo contrario, lo lanza 45º en dirección a la izquierda.
        RaycastHit2D[] hits;
        if (mirandoDerecha == true)
        {
            hits = Physics2D.RaycastAll(GetComponent<Rigidbody2D>().transform.position, new Vector2(1f, 1f));
        }
        else
        {
            hits = Physics2D.RaycastAll(GetComponent<Rigidbody2D>().transform.position, new Vector2(-1f, 1f));
        }

        for (int i = 0; i < hits.Length; i++)
        {
            // Cuando detecta uno o varios Collider al disparar los Raycast, dichos Collider son destruidos, aportando 50 puntos cada uno.
            if (hits[i].collider != null)
            {
                Destroy(hits[i].collider.gameObject);
                Destroy(hits[i].collider.gameObject.transform.parent.gameObject);
                contador.Puntos(50);
                Instantiate(masPuntos, hits[i].collider.transform.position, transform.rotation);
                // Si ademas dicho Collider es una Gelatina reparadora, ejecuta su función reparar (presente en el script GelatinaReparadora, el cual lleva el propio Blinky).
                if (hits[i].collider.gameObject.tag == "GelatinaReparadora")
                {
                    gameObject.GetComponent<GelatinaReparadora>().Reparar();
                }
            }
        }

        // Mientras dispara, se detiene durante 0.3", sin poder moverse.

        yield return new WaitForSecondsRealtime(.3f);
        blinkyAnim.SetBool("Disparo", false);
        puedeAndar = true;

    }

}