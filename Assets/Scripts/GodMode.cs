using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour {
	Muerte muerte;

	public void God () {
		muerte = GetComponent<Muerte> ();
		muerte.godMode = true;
	}

}
