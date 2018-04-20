using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Provoca que el objeto que lleva este script desaparezca paulatinamente antes de ser destruido.	
public class FadeOut : MonoBehaviour 
{	
	
	SpriteRenderer img;
	public int X = 1;
	public float Y = 1;
	
	void Start()
	{

		img = GetComponent<SpriteRenderer>();
		StartCoroutine("Fade");
		Destroy (gameObject, X);		// El objeto es destruido 1 segundo después de iniciar el FadeOut, dando la sensación de desaparecer.
	
	}

	// Reduce paulatinamente el Alpha del objeto que lleva el script, en función al tiempo transcurrido.
	IEnumerator Fade()
	{
			for (float i = 1; i >= 0; i -= Time.deltaTime*Y)
			{
				img.color = new Color (1, 1, 1, i);
				yield return null;
			}
		}

}
	