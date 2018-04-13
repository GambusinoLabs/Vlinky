using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de hacer aparecer a Din cada vez que una baldosa es destruida y activarlo cuando es necesario repararla.
public class BaldosaRota : MonoBehaviour 
{
	
	// fields
	Din DinNuevo;						
	Vector2 Altura;						

	// properties
	public Din Din;						// Instanciar el Prefab de Din.
	public float Y = 0;					// Indicar la altura a la que debe aparecer Din respecto al suelo.
	public GameObject baldosaSana;		// Instanciar el Prefab de la baldosa.



	// methodos
	void Start() 
	{
		
		Altura = new Vector2(transform.position.x, transform.position.y + Y);	// Establece el vector de la posición a la que aparece Din.
		DinNuevo = Instantiate(Din, Altura, transform.rotation);				// Hace aparecer a Din en la posición indicada.

	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.tag == "Din")
		{
			StartCoroutine ("Sustitucion");
		}
	}

	public void ActivarDin()
	{
		
		// Activa la animación de Din para bajar a arreglar la baldosa.
		DinNuevo.dinBajando = true;			
	
	}

	IEnumerator Sustitucion(){
		yield return new WaitForSeconds (.2f);
		Instantiate (baldosaSana, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
