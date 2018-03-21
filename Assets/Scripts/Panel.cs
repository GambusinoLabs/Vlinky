using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {
	public Animator anim;
	public Animator anim2;


	public void PanelIn () {
		anim.SetBool ("A", true);
		anim2.SetBool ("B", true);
	}
		
	public void PanelOut () {
		anim.SetBool ("A", false);
		anim2.SetBool ("B", false);
	}
}
