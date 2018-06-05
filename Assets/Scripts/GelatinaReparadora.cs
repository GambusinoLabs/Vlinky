using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Detecta la baldosa rota más cercana con el fin de repararla.
public class GelatinaReparadora : MonoBehaviour
{

    // fields
    float baldosaReparable1 = 0;
    float baldosaReparable2 = 0;
    GameObject baldosaDerecha;
    GameObject baldosaIzquierda;
    public static GameObject elegida = null;
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;

    // properties
    public GameObject baldosaSana;      // Arrastrar el prefab de la baldosa arreglada.

    // methods
    void Update()
    {

        // Lanza un rayo hacia la derecha y otro hacia a la izquierda con el fin de encontrar baldosas rotas.
        hitRight = Physics2D.Raycast(GetComponent<Rigidbody2D>().transform.position, Vector2.right, 300f);
        hitLeft = Physics2D.Raycast(GetComponent<Rigidbody2D>().transform.position, Vector2.left, 300f);
        if (hitRight.collider != null)
        {
            Right();
            RightLeft();
        }

        if (hitLeft.collider != null)
        {
            Left();
            RightLeft();
        }

    }

    void Right()
    {

        // Si el rayo impacta en un collider con el tag indicado, guarda la distancia a la que se encuentra y establece el objeto como baldosa rota a la derecha más cercana.
        if (hitRight.collider.tag == "BaldosaRota")
        {
            baldosaReparable1 = hitRight.distance;
            baldosaDerecha = hitRight.collider.gameObject;
        }

    }

    void Left()
    {

        // Si el rayo impacta en un collider con el tag indicado, guarda la distancia a la que se encuentra y establece el objeto como baldosa rota a la izquierda más cercana.
        if (hitLeft.collider.tag == "BaldosaRota")
        {
            baldosaReparable2 = hitLeft.distance;
            baldosaIzquierda = hitLeft.collider.gameObject;
        }

    }

    void RightLeft()
    {

        // Determina la baldosa rota más cercana comparando las detectadas a la derecha e izquierda del personaje.
        if ((baldosaDerecha == null) && (baldosaIzquierda != null))
        {
            elegida = baldosaIzquierda;
        }
        else if ((baldosaDerecha != null) && (baldosaIzquierda == null))
        {
            elegida = baldosaDerecha;
        }

        if ((baldosaDerecha != null) && (baldosaIzquierda != null) && (baldosaReparable1 < baldosaReparable2))
        {
            elegida = baldosaDerecha;
        }
        else if ((baldosaDerecha != null) && (baldosaIzquierda != null) && (baldosaReparable1 >= baldosaReparable2))
        {
            elegida = baldosaIzquierda;
        }

    }

    public void Reparar()
    {

        // Repara la baldosa elegida como más cercana.
        if (elegida != null)
        {
            elegida.GetComponent<BaldosaRota>().ActivarDin();
        }
    }

}
