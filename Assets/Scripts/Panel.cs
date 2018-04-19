using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de animar el panel del menu.
public class Panel : MonoBehaviour 
{
	
	// properties
	public Animator anim;
	public Animator anim2;

	// methods
	public void Settings() 
	{
		
		anim.SetBool("Settings", true);
		anim2.SetBool("Settings", true);

	}

	public void Credits() 
	{

		anim.SetBool("Credits", true);
		anim2.SetBool("Credits", true);

	}

	public void Scoreboards() 
	{

		anim.SetBool("Scoreboards", true);
		anim2.SetBool("Scoreboards", true);

	}
		
	public void Standar() 
	{
		
		anim.SetBool("Settings", false);
		anim2.SetBool("Settings", false);
		anim.SetBool("Credits", false);
		anim2.SetBool("Credits", false);
		anim.SetBool("Scoreboards", false);
		anim2.SetBool("Scoreboards", false);

	}

}
