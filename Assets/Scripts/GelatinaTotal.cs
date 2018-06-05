using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinaTotal : MonoBehaviour
{

    GameObject[] dins;
    GameObject[] gelatinas;
    /*GameObject dinMasCercano;
	float dinDistancia = Mathf.Infinity;
	Vector3 dinDiferencia;
	GameObject reparableMasCercana;
	float reparableDistancia = Mathf.Infinity;
	Vector3 reparableDiferencia;
	Vector3 position;*/

    public GameObject baldosaSana;
    public GameObject masPuntos;            // El objeto que se mostrará al destruir una gelatina.
    public GameObject masPuntos2;           // El objeto que se mostrará al destruir una gelatina.
    public GameObject masPuntos3;           // El objeto que se mostrará al destruir una gelatina.
    public GameObject masPuntos4;           // El objeto que se mostrará al destruir una gelatina.
    public Puntuacion contador;             // Aquí debe instanciarse el contador de puntos para que se sumen los puntos conseguidos.
    public int aciertos = 0;

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

    // Update is called once per frame
    void Update()
    {

        dins = GameObject.FindGameObjectsWithTag("Din");
        gelatinas = GameObject.FindGameObjectsWithTag("Enemigo");
        /*foreach (GameObject din in dins) 
		{
			dinDiferencia = din.transform.position - position;
			float dinCurDistance = dinDiferencia.sqrMagnitude;
			if (dinCurDistance < dinDistancia) {
				dinMasCercano = din;
				dinDistancia = dinCurDistance;
			}
		}*/


    }

    public IEnumerator DestroyAllEnemiesInScreen()
    {

        yield return new WaitForSeconds(.1f);
        foreach (GameObject gelatina in gelatinas)
        {
            Destroy(gelatina.transform.parent.gameObject);
            contador.GetComponent<Puntuacion>().Puntos(50);
            GameObject newGO = Instantiate(masPuntos, DynamicTransform);
            newGO.transform.position = gelatina.transform.position;
            newGO.transform.rotation = gelatina.transform.rotation;
        }
        // if (aciertos == 1)
        // {
        //     foreach (GameObject gelatina in gelatinas)
        //     {
        //         Destroy(gelatina.transform.parent.gameObject);
        //         contador.GetComponent<Puntuacion>().Puntos(50);
        //         GameObject newGO = Instantiate(masPuntos, DynamicTransform);
        //         newGO.transform.position = gelatina.transform.position;
        //         newGO.transform.rotation = gelatina.transform.rotation;
        //     }
        // }
        // if (aciertos == 2)
        // {
        //     foreach (GameObject gelatina in gelatinas)
        //     {
        //         Destroy(gelatina.transform.parent.gameObject);
        //         contador.GetComponent<Puntuacion>().Puntos(100);
        //         GameObject newGO = Instantiate(masPuntos2, DynamicTransform);
        //         newGO.transform.position = gelatina.transform.position;
        //         newGO.transform.rotation = gelatina.transform.rotation;
        //     }
        // }
        // if (aciertos == 3)
        // {
        //     foreach (GameObject gelatina in gelatinas)
        //     {
        //         Destroy(gelatina.transform.parent.gameObject);
        //         contador.GetComponent<Puntuacion>().Puntos(300);
        //         GameObject newGO = Instantiate(masPuntos3, DynamicTransform);
        //         newGO.transform.position = gelatina.transform.position;
        //         newGO.transform.rotation = gelatina.transform.rotation;
        //     }
        // }
        // if (aciertos >= 4)
        // {
        //     foreach (GameObject gelatina in gelatinas)
        //     {
        //         Destroy(gelatina.transform.parent.gameObject);
        //         contador.GetComponent<Puntuacion>().Puntos(1000);
        //         GameObject newGO = Instantiate(masPuntos4, DynamicTransform);
        //         newGO.transform.position = gelatina.transform.position;
        //         newGO.transform.rotation = gelatina.transform.rotation;
        //     }
        // }
    }

    public IEnumerator SendDinsToRepair()
    {
        foreach (GameObject din in dins)
        {
            yield return new WaitForSeconds(.2f);
            din.GetComponent<Din>().dinBajando = true;
        }

    }

}
