using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provoca que el objeto que lleve este script (las baldosas) se destruya al entrar en contacto con una Gelatina o Gelatina Reparadora (la cual también es destruida), dejando en su lugar un hueco (Baldosa rota).
public class Baldosas : MonoBehaviour 
{

	// properties
	public GameObject baldosarota;		// Objeto que contiene la baldosa rota.

	// methods
	void OnTriggerEnter2D(Collider2D col) 
	{

		if (col.gameObject.tag == "Enemigo") 
		{
			Instantiate(baldosarota, transform.position, transform.rotation);		// Hace aparecer un hueco (baldosa rota) en lugar de la baldosa destruida.
			Destroy(gameObject);													// Provoca que se rompa la baldosa al recibir un impacto de un enemigo.
			Destroy(col.gameObject);												// Provoca que el Trigger que ha hecho contacto con la baldosa se destruya.
			Destroy(col.gameObject.transform.parent.gameObject);					// Provoca que el padre del Trigger que ha hecho contacto se destruya también, desapareciendo la gelatina.
		}
			
	}
		
		
}

