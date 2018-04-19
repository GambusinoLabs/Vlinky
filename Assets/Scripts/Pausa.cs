using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour 
{

	public Animator anim;

	public void Pause () 
	{

		anim.SetBool ("Pausa", true);
		
	}

	public void Resume ()
	{

		anim.SetBool ("Pausa", false);

	}
}
