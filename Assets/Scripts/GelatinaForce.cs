using UnityEngine;
using System.Collections;
// Provoca que, al aparecer, el objeto que lleve este script sea impulsado por una fuerza en determinada dirección y una velocidad aleatoria con un rango definible.
public class GelatinaForce : MonoBehaviour 
{

	// fields
	Rigidbody2D rb;

	// properties 
	public GameObject explosion; 		// Instanciar el objeto que contiene la explosión de la gelatina.
	public int vel_maxima_X = 0;		// Determina la velocidad máxima a la que se moverá el objeto en el eje X.
	public int vel_maxima_Y = 600;		// Determina la velocidad máxima a la que se moverá el objeto en el eje Y.
	public int vel_maxima_Z = 0;		// Determina la velocidad mánima a la que se moverá el objeto en el eje Z.
	public int vel_minima_X = 0;		// Determina la velocidad mínima a la que se moverá el objeto en el eje X.
	public int vel_minima_Y = 400;		// Determina la velocidad mínima a la que se moverá el objeto en el eje Y.
	public int vel_minima_Z = 0;		// Determina la velocidad mínima a la que se moverá el objeto en el eje Z.

	// methods
	void Start() 
	{

		rb = GetComponent<Rigidbody2D>();
		// Provoca que se aplique una fuerza al Rigidbody que lleva este script, de manera aleatoria dentro de los rangos establecidos por los parametros anteriores.
		rb.AddForce (new Vector3(Random.Range(vel_minima_X,vel_maxima_X), Random.Range(vel_minima_Y,vel_maxima_Y), Random.Range(vel_minima_Z, vel_maxima_Z)));
	
	}

	void OnDestroy()
	{

		Instantiate (explosion, transform.position, transform.rotation);

	}
		
}