using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baldosas : MonoBehaviour {
	public GameObject baldosarota;

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Gelatina") {
			Destroy (gameObject);
			Destroy (col.gameObject);
			Instantiate (baldosarota, transform.position, transform.rotation);
		}
			
	}
}

