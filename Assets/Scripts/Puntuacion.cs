using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Se encarga de controlar el sistema de puntuación. Debe asignarse a un objeto vacío.
public class Puntuacion : MonoBehaviour 
{
	
	// fields
	int puntuacion = 0;							// Controla la puntuación actual.

	// properties
	public static int puntuacionmaxima = 0;		// Controla la puntuación máxima.
	public Text contador;						// Debe asignarse el texto que contiene la puntuación actual.
	public Text highscore;						// Debe asignarse el texto que contiene la puntuación máxima obtenida.

	// methods 
	void Start()
	{
		
		// Provoca que puntuacionmaxima se guarde permanentemente en el juego y se muestre siempre al iniciar la escena.
		puntuacionmaxima = PlayerPrefs.GetInt("puntuacionmaxima", puntuacionmaxima);
		highscore.text = puntuacionmaxima.ToString();

	}

	public void Puntos(int puntosganados) 
	{
		
		// Provoca que la puntuacion aumente en una cantidad igual a "puntosganados" al llamar esta función.
		puntuacion = puntuacion + puntosganados;	
		// Provoca que el contador refleje los cambios en la variable de puntuación.
		contador.text = puntuacion.ToString();		
		// Provoca que, si se supera la puntuación máxima, se sustituya por la nueva puntuación obtenida.
		if (puntuacion >= puntuacionmaxima) 
		{
			puntuacionmaxima = puntuacion;
			highscore.text = puntuacionmaxima.ToString();
			PlayerPrefs.SetInt("puntuacionmaxima", puntuacionmaxima);
		}

	}

}
