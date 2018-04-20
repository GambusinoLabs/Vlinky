using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour {
	MovieTexture movie;

	void OnAwake () {
		movie = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
		movie.Play ();
	}

}
