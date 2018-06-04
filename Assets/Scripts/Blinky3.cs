using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Controla el movimiento y disparo de Blinky, estrechamente relacionados. Versión botones (Móvil). Cada botón dispara en una dirección.
public class Blinky3 : MonoBehaviour
{

    // fields
    bool disparandoIzq = false;     // Determina si Blinky está disparando a la derecha o no.
    bool disparandoDer = false;     // Determina si Blinky está disparando a la izquierda o no.
    bool mirandoDerecha = true;     // Determina la dirección en la que está mirando Blinky, y por tanto en la que debe disparar.
    bool moverDer = false;          // Determina si Blinky se está moviendo a la derecha o no.
    bool moverIzq = false;          // Determina si Blinky se está moviendo a la izquierda o no.
    bool puedeAndar = true;         // Determina si Blinky puede moverse o no (por estar disparando).
    RaycastHit2D hit;

    // properties
    public Animator blinkyAnim;             // Animaciones del personaje.
    public GameObject masPuntos;            // El objeto que se mostrará al destruir una gelatina.
    public GameObject masPuntos2;           // El objeto que se mostrará al destruir una gelatina.
    public GameObject masPuntos3;           // El objeto que se mostrará al destruir una gelatina.
    public GameObject masPuntos4;           // El objeto que se mostrará al destruir una gelatina.
    public float velocidadMovimiento;       // Determina la velocidad del movimiento de Blinky.
    public float shotCooldown = 0.3f;       // 0.05 es un buen mínimo
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

        bool izqDerSimultanteos = (moverIzq && moverDer);

        if (!izqDerSimultanteos)
        {
            if ((moverIzq == true) && (puedeAndar == true))
            {
                // Provoca que Blinky camine hacia la izquierda, activando su animación y moviendolo.
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
                mirandoDerecha = false;
                blinkyAnim.SetBool("MirandoDer", false);
                blinkyAnim.SetBool("Andando", true);
            }

            if ((moverDer == true) && (puedeAndar == true))
            {
                // Provoca que Blinky camine hacia la derecha, activando su animación y moviendolo.
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimiento, GetComponent<Rigidbody2D>().velocity.y);
                mirandoDerecha = true;
                blinkyAnim.SetBool("MirandoDer", true);
                blinkyAnim.SetBool("Andando", true);
            }
        }

        if (izqDerSimultanteos || (moverDer == false) && (moverIzq == false))
        {
            // Provoca que Blinky detenga su movimiento.
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, GetComponent<Rigidbody2D>().velocity.y);
            blinkyAnim.SetBool("Andando", false);
        }


        if ((disparandoDer == true) && (puedeAndar == true))
        {
            // Inicia la Corrutina de Disparo.
            StartCoroutine("Disparo");
        }

        if ((disparandoIzq == true) && (puedeAndar == true))
        {
            // Inicia la Corrutina de Disparo.
            StartCoroutine("Disparo");
        }

        // Provisional para testear desde el editor
        if (Input.GetKeyDown(KeyCode.A))
        {
            DispararIzq();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DispararDer();
        }

        // Si el personaje está disparando, se detiene su movimiento.
        if (puedeAndar == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, GetComponent<Rigidbody2D>().velocity.y);
            blinkyAnim.SetBool("Andando", false);
            if (disparandoIzq == true)
            {
                blinkyAnim.SetBool("MirandoDer", false);

            }
            if (disparandoDer == true)
            {
                blinkyAnim.SetBool("MirandoDer", true);
            }

        }
    }


    bool IsGelatinaTag(string tag)
    {
        if (tag == "GelatinaTotal" || tag == "Gelatina" || tag == "GelatinaReparadora" || tag == "Enemigo")
            return true;
        else return false;
    }

    IEnumerator Disparo()
    {
        // Provoca que Blinky no pueda andar y activa la animación de disparo.
        puedeAndar = false;
        blinkyAnim.SetBool("Disparo", true);
        // Si el personaje dispara a la derecha, lanza un Raycast 45º en dirección a la derecha, si dispara a la izquierda, lo lanza 45º en dirección a la izquierda.
        RaycastHit2D[] hits;
        if (disparandoDer == true)
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
            if (hits[i].collider != null && IsGelatinaTag(hits[i].collider.tag))
            {
                //Destroy(hits [i].collider.gameObject);
                //print(hits[i].collider);
                Destroy(hits[i].collider.gameObject.transform.parent.gameObject);
                if (hits.Length == 1)
                {
                    GameObject newGO = Instantiate(masPuntos, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(50);
                }
                if (hits.Length == 2)
                {
                    GameObject newGO = Instantiate(masPuntos2, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(100);
                }
                if (hits.Length == 3)
                {
                    GameObject newGO = Instantiate(masPuntos3, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(300);
                }
                if (hits.Length >= 4)
                {
                    GameObject newGO = Instantiate(masPuntos4, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(1000);
                }
                // Si ademas dicho Collider es una Gelatina reparadora, ejecuta su función reparar (presente en el script GelatinaReparadora, el cual lleva el propio Blinky).
                if (hits[i].collider.gameObject.tag == "GelatinaReparadora")
                {
                    gameObject.GetComponent<GelatinaReparadora>().Reparar();
                }
                if (hits[i].collider.gameObject.tag == "GelatinaTotal")
                {
                    gameObject.GetComponent<GelatinaTotal>().aciertos = hits.Length;
                    gameObject.GetComponent<GelatinaTotal>().StartCoroutine("GelatinaTot");
                    gameObject.GetComponent<GelatinaTotal>().StartCoroutine("GelatinaTot1");
                }
            }
        }

        // Mientras dispara, se detiene durante 0.3", sin poder moverse. Posteriormente se reanuda el poder andar y finaliza la animación del disparo.
        yield return new WaitForSecondsRealtime(shotCooldown);
        blinkyAnim.SetBool("Disparo", false);
        puedeAndar = true;
        disparandoIzq = false;
        disparandoDer = false;


    }

    // De aqui en adelante las funciones activan las distintas acciones del script.
    public void MovimientoDer()
    {

        moverDer = true;

    }

    public void MovimientoIzq()
    {

        moverIzq = true;

    }

    public void MovimientoDerStop()
    {

        moverDer = false;

    }

    public void MovimientoIzqStop()
    {

        moverIzq = false;

    }

    public void DispararIzq()
    {

        blinkyAnim.SetBool("MirandoDer", false);
        disparandoIzq = true;

    }

    public void DispararDer()
    {

        blinkyAnim.SetBool("MirandoDer", true);
        disparandoDer = true;

    }



}