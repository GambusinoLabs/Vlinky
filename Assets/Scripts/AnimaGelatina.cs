using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Activa la animación de las gelatinas al ser creadas.
public class AnimaGelatina : MonoBehaviour 
{
	
	// fields
	Animator anim;
	int random;

	// methods
	void Start() 
	{
		// Provoca que se active una de las dos animaciones disponibles para la gelatina, de manera aleatoria, al ser creada.
		anim = GetComponent<Animator>();
		anim.SetInteger("Animacion", Random.Range(0, 2));

	}

}
