using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Provoca que el objeto que lleva este script desaparezca paulatinamente antes de ser destruido.	
public class FadeOut : MonoBehaviour 
{	

	SpriteRenderer img;
	
	void Start()
	{

		img = GetComponent<SpriteRenderer>();
		StartCoroutine("Fade");
		Destroy (gameObject, 1);
	
	}

	IEnumerator Fade()
	{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color (1, 1, 1, i);
				yield return null;
			}
		}

}
	