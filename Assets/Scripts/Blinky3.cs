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
    bool puedeDisparar = true;
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


        if ((disparandoDer == true) && (puedeDisparar == true))
        {
            // Inicia la Corrutina de Disparo.
            StartCoroutine("Disparo");
        }

        if ((disparandoIzq == true) && (puedeDisparar == true))
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

    private int CountGelatinesInRaycast(RaycastHit2D[] hits)
    {
        int howMany = 0;
        foreach (RaycastHit2D h in hits)
        {
            if (h.collider.tag == "ColliderDestructor")
                howMany++;
        }
        return howMany;
    }

    IEnumerator Disparo()
    {
        // Provoca que Blinky no pueda andar y activa la animación de disparo.
        puedeAndar = false;
        puedeDisparar = false;
        blinkyAnim.SetBool("Disparo", true);
        AudioManager.instance.Play("Disparo");

        // Si el personaje dispara a la derecha, lanza un Raycast 45º en dirección a la derecha, si dispara a la izquierda, lo lanza 45º en dirección a la izquierda.
        RaycastHit2D[] hits;
        if (disparandoDer == true)
        {
            hits = Physics2D.RaycastAll(GetComponent<Rigidbody2D>().transform.position + 0.15f * Vector3.down, new Vector2(1f, 1f));
        }
        else
        {
            hits = Physics2D.RaycastAll(GetComponent<Rigidbody2D>().transform.position + 0.15f * Vector3.down, new Vector2(-1f, 1f));
        }

        int alineados = CountGelatinesInRaycast(hits);

        for (int i = 0; i < hits.Length; i++)
        {
            // Cuando detecta uno o varios Collider al disparar los Raycast, dichos Collider son destruidos, aportando 50 puntos cada uno.
            if (hits[i].collider != null && hits[i].collider.tag == "ColliderDestructor")
            {
                //Destroy(hits [i].collider.gameObject);
                //print(hits[i].collider);
                Destroy(hits[i].collider.gameObject.transform.parent.gameObject);

                if (alineados == 1)
                {
                    GameObject newGO = Instantiate(masPuntos, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(50);
                }
                if (alineados == 2)
                {
                    GameObject newGO = Instantiate(masPuntos2, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(100);
                }
                if (alineados == 3)
                {
                    GameObject newGO = Instantiate(masPuntos3, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(300);
                }
                if (alineados >= 4)
                {
                    GameObject newGO = Instantiate(masPuntos4, DynamicTransform);
                    newGO.transform.position = hits[i].collider.transform.position;
                    newGO.transform.rotation = transform.rotation;
                    contador.GetComponent<Puntuacion>().Puntos(1000);
                }

                // Si ademas dicho Collider es una Gelatina reparadora, ejecuta su función reparar (presente en el script GelatinaReparadora, el cual lleva el propio Blinky).
                if (hits[i].collider.transform.parent.gameObject.tag == "GelatinaReparadora")
                {
                    gameObject.GetComponent<GelatinaReparadora>().Reparar();
                }
                if (hits[i].collider.transform.parent.gameObject.tag == "GelatinaTotal")
                {
                    gameObject.GetComponent<GelatinaTotal>().aciertos = hits.Length;
                    gameObject.GetComponent<GelatinaTotal>().StartCoroutine("DestroyAllEnemiesInScreen");
                    gameObject.GetComponent<GelatinaTotal>().StartCoroutine("SendDinsToRepair");
                }
            }


        }

        // Mientras dispara, se detiene durante 0.3", sin poder moverse. Posteriormente se reanuda el poder andar y finaliza la animación del disparo.
        yield return new WaitForSecondsRealtime(shotCooldown);
        blinkyAnim.SetBool("Disparo", false);
        disparandoIzq = false;
        disparandoDer = false;
        puedeDisparar = true;
        StopCoroutine("RestaurarPuedeAndar");
        StartCoroutine(RestaurarPuedeAndar(0.05f));
    }

    IEnumerator RestaurarPuedeAndar(float wait)
    {
        yield return new WaitForSecondsRealtime(wait);
        puedeAndar = true;
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

    public void Disparar()
    {
        if (GetComponent<SpriteRenderer>().flipX)
            DispararDer();
        else
            DispararIzq();
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