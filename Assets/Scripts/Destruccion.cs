using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Provoca que cualquier Trigger que entre en contacto con el objeto que lleva este script sea destruido, así como su parental.
public class Destruccion : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D col) 
	{
		Destroy (col.gameObject.transform.parent.gameObject);
		Destroy(col.gameObject);
		
	}

}
