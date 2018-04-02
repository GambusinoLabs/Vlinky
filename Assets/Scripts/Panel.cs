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
	public void PanelIn() 
	{
		
		anim.SetBool("A", true);
		anim2.SetBool("B", true);

	}
		
	public void PanelOut() 
	{
		
		anim.SetBool("A", false);
		anim2.SetBool("B", false);

	}

}
