using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour {
	public float velocidadMovimiento;
	private bool puedeandar = true;
	private bool mirandoderecha = true;
	private RaycastHit2D hit;
	public Puntuacion contador;
	private float tiempoCD;

	void FixedUpdate (){
		Movimiento ();
		if (Input.GetKeyDown (KeyCode.Space) && tiempoCD <= Time.time) {
			StartCoroutine("Disparo");
			}
		}

	void Movimiento (){
		if (Input.GetKey (KeyCode.A) && puedeandar == true) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			mirandoderecha = false;
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, GetComponent<Rigidbody2D> ().velocity.y);
		}


		if (Input.GetKey (KeyCode.D)  && puedeandar == true) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			mirandoderecha = true;
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, GetComponent<Rigidbody2D> ().velocity.y);

		}
	}

	 void Disparo (){
		RaycastHit2D[] hits;
		if (mirandoderecha == true) {
			hits = Physics2D.RaycastAll (GetComponent<Rigidbody2D> ().transform.position, new Vector2 (1f, 1f));
		} else {
			hits = Physics2D.RaycastAll (GetComponent<Rigidbody2D> ().transform.position, new Vector2 (-1f, 1f));
		}

		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].collider != null) {
				Debug.Log ("HAY ALGO");
					print (hits[i].distance);
					Destroy (hits [i].collider.gameObject);
					contador.Puntos (50);
				if (hits [i].collider.gameObject.tag == "GelatinaReparadora") {
					GelatinaReparadora.Reparar ();
				}
				}
			}
		tiempoCD = Time.time + .25f;
		}
	}