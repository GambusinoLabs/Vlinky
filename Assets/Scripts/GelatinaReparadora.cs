using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelatinaReparadora : MonoBehaviour 
{
	
	// fields
	float baldosareparable1 = 0;
	float baldosareparable2 = 0;
	GameObject baldosaderecha;
	GameObject baldosaizquierda;
	GameObject elegida;
	RaycastHit2D hitLeft;
	RaycastHit2D hitRight;

	// properties
	public GameObject baldosasana;

	// methods
	void Update()
	{
		
		hitRight = Physics2D.Raycast (GetComponent<Rigidbody2D> ().transform.position, Vector2.right, 300f);
		hitLeft = Physics2D.Raycast (GetComponent<Rigidbody2D> ().transform.position, Vector2.left, 300f);
		if (hitRight.collider != null)
		{
			Right();
			RightLeft();
		}

		if (hitLeft.collider != null) 
		{
			Left();
			RightLeft();
		}

	}

	void Right()
	{
		
		if (hitRight.collider.tag == "BaldosaRota") 
		{
			baldosareparable1 = hitRight.distance;
			baldosaderecha = hitRight.collider.gameObject;
		}

	}

	void Left()
	{
		if (hitLeft.collider.tag == "BaldosaRota") 
		{
			baldosareparable2 = hitLeft.distance;
			baldosaizquierda = hitLeft.collider.gameObject;
		}

	}

	void RightLeft()
	{

		if ((baldosaderecha == null) && (baldosaizquierda != null))
		{
			elegida = baldosaizquierda;
		}
		else if ((baldosaderecha != null) && (baldosaizquierda == null))
		{
			elegida = baldosaderecha;
		}

		if ((baldosaderecha != null) && (baldosaizquierda != null) && (baldosareparable1 < baldosareparable2)) 
		{
			elegida = baldosaderecha;
		} 
		else if ((baldosaderecha != null) && (baldosaizquierda != null) && (baldosareparable1 >= baldosareparable2)) 
		{
			elegida = baldosaizquierda;
		}

	}

	public void Reparar()
	{
		
		Destroy(elegida);
		Instantiate(baldosasana, elegida.transform.position, elegida.transform.rotation);

	}
		
}
