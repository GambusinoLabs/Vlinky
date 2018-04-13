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
	public bool dinBajando = false;		// Inicia la acción de descenso de Din. Se llama desde el Script "Baldosa Rota".
	public float Y = 0;					// Determina la velocidad de bajada de Din.

	// methods
	void Start() 
	{
		
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	void Update() 
	{
		// Provoca que Din comience a descender cuando se activa el bool dinBajando, activando su animación.
		if (dinBajando == true) 
		{
			rb.velocity = new Vector2(0, Y);
			anim.SetBool("Din", true);
		}

		StartCoroutine("AnimacionDin");

	}

	void OnTriggerEnter2D(Collider2D col)
	{

		// Provoca que, al tocar Din el suelo, se destruya el objeto de la baldosa rota establecida anteriormente como reparable, y se instancie una sana en su lugar.
		if (col.tag == "ActivaDin") 
		{
			tocandoSuelo = true;
			dinBajando = false;
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
