using UnityEngine;
using System.Collections;
// Provoca que, al aparecer, el objeto que lleve este script sea impulsado por una fuerza en determinada dirección y una velocidad aleatoria con un rango definible.
public class GelatinaForce : MonoBehaviour
{

    // fields
    Rigidbody2D rb;

    // properties 
    public GameObject explosion;        // Instanciar el objeto que contiene la explosión de la gelatina.
    public float velocidad = 100.0f;

    // methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Provoca que se aplique una fuerza al Rigidbody que lleva este script, de manera aleatoria dentro de los rangos establecidos por los parametros anteriores.
        //rb.AddForce(new Vector3(0.0f, -velocidad, 0.0f));
        rb.velocity = velocidad * Vector2.down;

    }

    void OnDestroy()
    {
        // Provoca que, al ser destruido el objeto, se genere el objeto que contiene la animación de la explosión.
        if (!SceneManagement.isChangingScene)
            Instantiate(explosion, transform.position, transform.rotation);

    }

}