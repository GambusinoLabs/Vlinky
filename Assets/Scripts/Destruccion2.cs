using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Destruye un objeto 1 segundo después de ser creado.
public class Destruccion2 : MonoBehaviour 
{

	void Start() 
	{

		Destroy(gameObject, 1);
	
	}

}
