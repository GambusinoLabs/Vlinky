using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Pausa : MonoBehaviour 
{
	public VideoPlayer video;

	public Animator anim;

	public void Pause () 
	{

		anim.SetBool ("Pausa", true);
		video.Pause ();
		
	}

	public void Resume ()
	{

		anim.SetBool ("Pausa", false);
		video.Play ();

	}
}
