using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionDin : MonoBehaviour 
{

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.tag == "Din") 
		{
			Destroy (col.gameObject);

		}

	}

}
