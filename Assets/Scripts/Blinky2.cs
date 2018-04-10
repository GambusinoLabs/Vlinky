using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de regular el movimiento y los disparos de Blinky, estrechamente relacionados entre ellos. 
public class Blinky2 : MonoBehaviour 
{

	// fields
	bool disparando = false;   		// Determina si Blinky está disparando o no.
	bool mirandoDerecha = true;		// Determina la dirección en la que está mirando Blinky, y por tanto en la que debe disparar.
	bool moverDer = false;			// Determina si Blinky se está moviendo a la derecha o no.
	bool moverIzq = false;			// Determina si Blinky se está moviendo a la izquierda o no.
	bool puedeAndar = true;			// Determina si Blinky puede moverse o no (por estar disparando).


	RaycastHit2D hit;

	// properties
	public Animator blinkyAnim;
	public GameObject masPuntos;
	public float velocidadMovimiento;		// Determina la velocidad del movimiento de Blinky.
	public Puntuacion contador;				// Aquí debe instanciarse el contador de puntos para que se sumen los puntos conseguidos.

	// methods
	void FixedUpdate()
	{

		if (moverIzq == true && puedeAndar == true) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			mirandoDerecha = false;
			blinkyAnim.SetBool ("MirandoDer", false);
			blinkyAnim.SetBool ("Andando", true);
		}

		if (moverDer == true && puedeAndar == true)
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			mirandoDerecha = true;
			blinkyAnim.SetBool ("MirandoDer", true);
			blinkyAnim.SetBool ("Andando", true);
		}

		if (moverDer == false && moverIzq == false) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, GetComponent<Rigidbody2D> ().velocity.y);
			blinkyAnim.SetBool("Andando", false);
		}
			

		if ((disparando == true) && (puedeAndar == true))
		{
			StartCoroutine("Disparo");
		}

	}

	void LateUpdate()
	{

		// Si el personaje está disparando, se detiene su movimiento.
		if (puedeAndar == false)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, GetComponent<Rigidbody2D> ().velocity.y);
			blinkyAnim.SetBool("Andando", false);
		}

	}
		
		

	IEnumerator Disparo()
	{

		puedeAndar = false;
		blinkyAnim.SetBool ("Disparo", true);
		// Si el personaje se haya mirando a la derecha, lanza un Raycast 45º en dirección a la derecha, de lo contrario, lo lanza 45º en dirección a la izquierda.
		RaycastHit2D[] hits;
		if (mirandoDerecha == true) 
		{
			hits = Physics2D.RaycastAll (GetComponent<Rigidbody2D> ().transform.position, new Vector2 (1f, 1f));
		} 
		else 
		{
			hits = Physics2D.RaycastAll (GetComponent<Rigidbody2D> ().transform.position, new Vector2 (-1f, 1f));
		}

		for (int i = 0; i < hits.Length; i++) 
		{
			// Cuando detecta uno o varios Collider al disparar los Raycast, dichos Collider son destruidos, aportando 50 puntos cada uno.
			if (hits[i].collider != null) 
			{
				//Destroy(hits [i].collider.gameObject);
				print (hits[i].collider);
				Destroy(hits[i].collider.gameObject.transform.parent.gameObject);
				contador.GetComponent<Puntuacion> ().Puntos (50);
				Instantiate (masPuntos, hits [i].collider.transform.position, transform.rotation);
				// Si ademas dicho Collider es una Gelatina reparadora, ejecuta su función reparar (presente en el script GelatinaReparadora, el cual lleva el propio Blinky).
				if (hits [i].collider.gameObject.tag == "GelatinaReparadora") 
				{
					gameObject.GetComponent<GelatinaReparadora>().Reparar();
				}
			}
		}

		// Mientras dispara, se detiene durante 0.3", sin poder moverse.
		yield return new WaitForSecondsRealtime(.3f);
		blinkyAnim.SetBool ("Disparo", false);
		puedeAndar = true;
		disparando = false;

	}

	public void MovimientoDer()
	{
		
		moverDer = true;

	}

	public void MovimientoIzq()
	{
		
		moverIzq = true;

	}

	public void MovimientoDerStop()
	{
		
		moverDer = false;

	}

	public void MovimientoIzqStop()
	{
		
		moverIzq = false;

	}

	public void Disparar()
	{
		
		disparando = true;

	}

}