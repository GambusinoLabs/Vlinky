using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de controlar el sistema de muerte del personaje. Debe asignarse al personaje.
public class Muerte : MonoBehaviour {
	
	// properties
	public Animator blinkyAnim;
	public restart reiniciar;	 // Debe asignarse un objeto con el script restart.

	// methods
	IEnumerator OnTriggerEnter2D(Collider2D col)
	{
		
		// Provoca que, si el objeto que lleva este script entra en contacto con una gelatina, sea destruido y la escena se reinicie.
		if (col.gameObject.tag == "Gelatina") 
		{	
			Destroy(col.gameObject);
			Destroy(col.gameObject.transform.parent.gameObject);
			blinkyAnim.SetBool("Muere", true);
			yield return new WaitForSecondsRealtime(2);
			Destroy(gameObject);
			reiniciar.ResetearEscena();
		}

		// Provoca que, si el objeto que lleva este script entra en contacto con una gelatina reparadora, sea destruido y la escena se reinicie.
		if (col.gameObject.tag == "GelatinaReparadora") 
		{
			Destroy(col.gameObject);
			Destroy(col.gameObject.transform.parent.gameObject);
			blinkyAnim.SetBool("Muere", true);
			yield return new WaitForSecondsRealtime(2);
			Destroy(gameObject);
			reiniciar.ResetearEscena();
		}

	}

}
