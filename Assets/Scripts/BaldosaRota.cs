using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldosaRota : MonoBehaviour {
	public Din Din;
	Din DinNuevo;
	public float Y = 0;
	Vector2 Altura;
	public GameObject baldosaSana;


	// Use this for initialization
	void Start () 
	{
		Altura = new Vector2 (transform.position.x, transform.position.y + Y);
		DinNuevo = Instantiate (Din, Altura, transform.rotation);

	}

	public void ActivarDin ()
	{
		DinNuevo.dinBajando = true;
	}

	void OnDestroy()
	{

		Instantiate (baldosaSana, transform.position, transform.rotation);

	}

}
