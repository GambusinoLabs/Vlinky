using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de controlar el sistema de muerte del personaje. Debe asignarse al personaje.
public class Muerte : MonoBehaviour {
	
	// properties
	public Animator blinkyAnim;
	public Retry reiniciar;	 // Debe asignarse un objeto con el script restart.
	public float Y;
	public bool godMode = false;
	Blinky3 blinky;

	// methods
	IEnumerator OnTriggerEnter2D(Collider2D col)
	{
		if (godMode == true) {
			Debug.Log ("NO PUEDO MORIR");
			Destroy (col.gameObject);
			Destroy (col.gameObject.transform.parent.gameObject);
		} 
		else 
		{
			blinky = GetComponent<Blinky3> ();
			// Provoca que, si el objeto que lleva este script entra en contacto con una gelatina, sea destruido y la escena se reinicie.
			if (col.gameObject.tag == "Gelatina") {	
				blinky.enabled = !blinky.enabled;
				Destroy (col.gameObject);
				Destroy (col.gameObject.transform.parent.gameObject);
				blinkyAnim.SetBool ("Muere", true);
				GetComponent<Collider2D> ().isTrigger = true;
				GetComponent<Rigidbody2D> ().gravityScale = 0;
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, Y / 3);
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -Y / 2);
				yield return new WaitForSecondsRealtime (2);
				Destroy (gameObject);
				reiniciar.RetryGame ();
			}

			// Provoca que, si el objeto que lleva este script entra en contacto con una gelatina reparadora, sea destruido y la escena se reinicie.
			if (col.gameObject.tag == "GelatinaReparadora") {
				blinky.enabled = !blinky.enabled;
				Destroy (col.gameObject);
				Destroy (col.gameObject.transform.parent.gameObject);
				blinkyAnim.SetBool ("Muere", true);
				GetComponent<Collider2D> ().isTrigger = true;
				GetComponent<Rigidbody2D> ().gravityScale = 0;
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, Y / 3);
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -Y / 2);
				yield return new WaitForSecondsRealtime (2);
				Destroy (gameObject);
				reiniciar.RetryGame ();
			}

			if (col.gameObject.tag == "GelatinaTotal") {	
				blinky.enabled = !blinky.enabled;
				Destroy (col.gameObject);
				Destroy (col.gameObject.transform.parent.gameObject);
				blinkyAnim.SetBool ("Muere", true);
				GetComponent<Collider2D> ().isTrigger = true;
				GetComponent<Rigidbody2D> ().gravityScale = 0;
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, Y / 3);
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				yield return new WaitForSecondsRealtime (0.1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -Y / 2);
				yield return new WaitForSecondsRealtime (2);
				Destroy (gameObject);
				reiniciar.RetryGame ();
			}
		}
	}

}
