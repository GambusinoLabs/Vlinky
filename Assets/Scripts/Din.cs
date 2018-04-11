using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Controla la animación de Din para arreglar las baldosas rotas.
public class Din : MonoBehaviour 
{

	// fields
	Animator anim;
	bool tocandoSuelo = false;
	Rigidbody2D rb;
	GameObject reparable;

	// properties
	public bool dinBajando = false;
	public float Y = 0;



	// methods
	void Start() 
	{
		
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	void Update() 
	{
		// Provoca que Din comience a descender cuando se activa el bool dinBajando.
		if (dinBajando == true) 
		{
			rb.velocity = new Vector2(0, Y);
			anim.SetBool("Din", true);
			if (reparable == null) {
				reparable = GelatinaReparadora.elegida;
			}
		}

		StartCoroutine("AnimacionDin");

	}

	void OnTriggerEnter2D(Collider2D col)
	{

		// Provoca que, al tocar Din el suelo, se destruya el objeto la baldosa rota (el cual instancia una sana).
		if (col.tag == "ActivaDin") 
		{
			tocandoSuelo = true;
			dinBajando = false;
			Destroy (reparable);
		}

	}

	IEnumerator AnimacionDin()
	{

		// Din se detiene al tocar el suelo, y tras ello vuelve a ascender para salir de la pantalla.
		if (tocandoSuelo == true) 
		{
			rb.velocity = new Vector2(0, 0);
			yield return new WaitForSecondsRealtime(.2f);
			rb.velocity = new Vector2(0, -Y);
		}
			
	}

}
