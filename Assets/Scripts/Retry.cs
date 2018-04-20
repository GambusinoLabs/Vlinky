using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour {
	public Animator anim;

	public void RetryGame () 
	{

		anim.SetBool ("Pausa", true);

	}
		
}
