using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de hacer aparecer a Din cada vez que una baldosa es destruida, así como hacer volver a aparecer las baldosas sanas.
public class BaldosaRota : MonoBehaviour 
{
	
	// fields
	Din DinNuevo;						
	Vector2 Altura;						

	// properties
	public Din Din;						// Instanciar el Prefab de Din.
	public float Y = 0;					// Indicar la altura a la que debe aparecer Din respecto al suelo.
	public GameObject baldosaSana;		// Instanciar el Prefab de Baldosa.


	// methodos
	void Start() 
	{
		
		Altura = new Vector2(transform.position.x, transform.position.y + Y);	// Establece el vector de la posición a la que aparece Din.
		DinNuevo = Instantiate(Din, Altura, transform.rotation);				// Hace aparecer a Din en la posición indicada.

	}


	public void ActivarDin()
	{
		
		// Activa la animación de Din para bajar a arreglar la baldosa.
		DinNuevo.dinBajando = true;			
	
	}


	void OnDestroy()
	{
		
		// Hace aparecer una baldosa sana en el lugar donde estaba esta.
		Instantiate(baldosaSana, transform.position, transform.rotation);

	}

}
