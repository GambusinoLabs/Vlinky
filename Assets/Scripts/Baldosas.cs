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

		if (col.gameObject.tag == "Gelatina") 
		{
			Destroy(gameObject);
			Destroy(col.gameObject);
			Instantiate(baldosarota, transform.position, transform.rotation);
		}

		if (col.gameObject.tag == "GelatinaReparadora") 
		{
			Destroy(gameObject);
			Destroy(col.gameObject);
			Instantiate(baldosarota, transform.position, transform.rotation);
		}
			
	}

}

