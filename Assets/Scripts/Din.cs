using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Din : MonoBehaviour {
	Animator anim;
	bool tocandoSuelo = false;
	Rigidbody2D rb;

	public float Y = 0;
	public bool dinBajando = false;


	// Use this for initialization
	void Start () 
	{
		
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (dinBajando == true) 
		{
			rb.velocity = new Vector2 (0, Y);
			anim.SetBool ("Din", true);
		}

		StartCoroutine("AnimacionDin");

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		
		if (col.tag == "ActivaDin") 
		{
			tocandoSuelo = true;
			dinBajando = false;
			Destroy (GelatinaReparadora.elegida);
		}

	}

	IEnumerator AnimacionDin()
	{

		if (tocandoSuelo == true) 
		{
			rb.velocity = new Vector2 (0, 0);
			yield return new WaitForSecondsRealtime (.2f);
			rb.velocity = new Vector2 (0, -Y);
		}


	}
}
