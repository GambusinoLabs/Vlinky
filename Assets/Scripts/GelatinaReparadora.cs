using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinaReparadora : MonoBehaviour {
	RaycastHit2D hitRight;
	RaycastHit2D hitLeft;
	private float baldosareparable1 = 0;
	private float baldosareparable2 = 0;
	private GameObject elegida;
	public GameObject baldosasana;

	void Update(){
		hitRight = Physics2D.Raycast (GetComponent<Rigidbody2D> ().transform.position, Vector2.right);
		hitLeft = Physics2D.Raycast (GetComponent<Rigidbody2D> ().transform.position, Vector2.left);
		if (hitRight.collider != null) {
			Right ();
			RightLeft ();
		}

		if (hitLeft.collider != null) {
			Left ();
			RightLeft ();
		}
	}

	void Right (){
		if (hitRight.collider.tag == "BaldosaRota") {
			Debug.Log ("HOLA");
			baldosareparable1 = hitRight.distance;
		}
	}

	void Left (){
		if (hitLeft.collider.tag == "BaldosaRota") {
			Debug.Log ("ADIOS");
			baldosareparable2 = hitLeft.distance;
		}
	}
	void RightLeft (){
		if (baldosareparable1 < baldosareparable2) {
			elegida = hitRight.collider.gameObject;
		} else if (baldosareparable1 >= baldosareparable2) {
			elegida = hitLeft.collider.gameObject;
		}
			print (elegida);
	}

	public void Reparar (){
		Destroy (elegida);
		Instantiate (baldosasana, elegida.transform.position, elegida.transform.rotation);
	}
}
