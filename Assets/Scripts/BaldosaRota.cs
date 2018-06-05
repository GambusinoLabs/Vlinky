using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de hacer aparecer a Din cada vez que una baldosa es destruida y activarlo cuando es necesario repararla.
public class BaldosaRota : MonoBehaviour
{

    // fields
    Din DinNuevo;
    Vector2 Altura;

    // properties
    public Din Din;                     // Instanciar el Prefab de Din.
    public float Y = 0;                 // Indicar la altura a la que debe aparecer Din respecto al suelo.
    public GameObject baldosaSana;      // Instanciar el Prefab de la baldosa.

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

    private Transform m_baldosasTransform;
    private Transform BaldosasTransform
    {
        get
        {
            if (m_baldosasTransform != null)
                return m_baldosasTransform;
            else
            {
                GameObject baldosasGameObject = GameObject.FindGameObjectWithTag("Baldosas");
                m_baldosasTransform = baldosasGameObject.transform;
                return m_baldosasTransform;
            }
        }
    }

    // methodos
    void Start()
    {

        Altura = new Vector2(transform.position.x, transform.position.y + Y);   // Establece el vector de la posición a la que aparece Din.

        // Hace aparecer a Din en la posición indicada.
        DinNuevo = Instantiate(Din, DynamicTransform);
        DinNuevo.transform.position = Altura;
        DinNuevo.transform.rotation = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Din")
        {
            StartCoroutine("Sustitucion");
        }
    }

    public void ActivarDin()
    {

        // Activa la animación de Din para bajar a arreglar la baldosa.
        DinNuevo.dinBajando = true;

    }

    IEnumerator Sustitucion()
    {
        yield return new WaitForSeconds(.2f);
        GameObject newBaldosa = Instantiate(baldosaSana, BaldosasTransform);
        newBaldosa.transform.position = transform.position;
        newBaldosa.transform.rotation = transform.rotation;
        Destroy(gameObject);
    }
}
