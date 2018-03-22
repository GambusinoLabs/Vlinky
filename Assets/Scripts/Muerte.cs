using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour {
	public restart reiniciar;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Gelatina") {
			Destroy (gameObject);
			reiniciar.ResetearEscena ();
		}
	}
}
