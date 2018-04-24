using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FalsoFondo : MonoBehaviour {
	public VideoPlayer video;


	void Update () 
	{

		if (video.isPlaying == true) 
		{
			Destroy (gameObject, 0.1f);
		}

	}
}
