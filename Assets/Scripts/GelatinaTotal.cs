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
	public GameObject masPuntos;			// El objeto que se mostrará al destruir una gelatina.
	public GameObject masPuntos2;			// El objeto que se mostrará al destruir una gelatina.
	public GameObject masPuntos3;			// El objeto que se mostrará al destruir una gelatina.
	public GameObject masPuntos4;			// El objeto que se mostrará al destruir una gelatina.
	public Puntuacion contador;				// Aquí debe instanciarse el contador de puntos para que se sumen los puntos conseguidos.
	public int aciertos = 0;
	
	// Update is called once per frame
	void Update () 
	{
		
		dins = GameObject.FindGameObjectsWithTag ("Din");
		gelatinas = GameObject.FindGameObjectsWithTag ("Enemigo");
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

	public IEnumerator GelatinaTot()
	{
		
		yield return new WaitForSeconds (.1f);
		if (aciertos == 1) {
			foreach (GameObject gelatina in gelatinas) {
				Destroy (gelatina.transform.parent.gameObject);
				contador.GetComponent<Puntuacion> ().Puntos (50);
				Instantiate (masPuntos, gelatina.transform.position, gelatina.transform.rotation);
			}
		}
		if (aciertos == 2) {
			foreach (GameObject gelatina in gelatinas) {
				Destroy (gelatina.transform.parent.gameObject);
				contador.GetComponent<Puntuacion> ().Puntos (100);
				Instantiate (masPuntos2, gelatina.transform.position, gelatina.transform.rotation);
			}
		}
		if (aciertos == 3) {
			foreach (GameObject gelatina in gelatinas) {
				Destroy (gelatina.transform.parent.gameObject);
				contador.GetComponent<Puntuacion> ().Puntos (300);
				Instantiate (masPuntos3, gelatina.transform.position, gelatina.transform.rotation);
			}
		}
		if (aciertos >= 4) {
			foreach (GameObject gelatina in gelatinas) {
				Destroy (gelatina.transform.parent.gameObject);
				contador.GetComponent<Puntuacion> ().Puntos (1000);
				Instantiate (masPuntos4, gelatina.transform.position, gelatina.transform.rotation);
			}
		}
	}

	public IEnumerator GelatinaTot1()
	{
		foreach (GameObject din in dins) 
		{
			yield return new WaitForSeconds(.2f);
			din.GetComponent<Din> ().dinBajando = true;
		}
	
	}

}
