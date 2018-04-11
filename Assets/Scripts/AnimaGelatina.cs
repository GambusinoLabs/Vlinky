using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaGelatina : MonoBehaviour 
{
	Animator anim;
	int random;

	// Use this for initialization
	void Start() 
	{
		
		anim = GetComponent<Animator>();
		anim.SetInteger("Animacion", Random.Range(0, 2));

	}

}
