using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provoca que el objeto que lleve este script (las baldosas) se destruya al entrar en contacto con una Gelatina o Gelatina Reparadora (la cual también es destruida), dejando en su lugar un hueco (Baldosa rota).
public class Baldosas : MonoBehaviour
{

    // properties
    public GameObject baldosarota;      // Objeto que contiene la baldosa rota.

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
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Enemigo")
        {
            // Hace aparecer un hueco (baldosa rota) en lugar de la baldosa destruida.
            GameObject newGO = Instantiate(baldosarota, DynamicTransform);
            newGO.transform.position = transform.position;
            newGO.transform.rotation = transform.rotation;
            Destroy(gameObject);                                                    // Provoca que se rompa la baldosa al recibir un impacto de un enemigo.
            Destroy(col.gameObject);                                                // Provoca que el Trigger que ha hecho contacto con la baldosa se destruya.
            Destroy(col.gameObject.transform.parent.gameObject);                    // Provoca que el padre del Trigger que ha hecho contacto se destruya también, desapareciendo la gelatina.
        }

    }


}

