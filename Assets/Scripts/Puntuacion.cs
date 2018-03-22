using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour {
	public Text contador;
	public Text highscore;
	private int puntuacion = 0;
	public static int puntuacionmaxima = 0;

	void Start (){
		puntuacionmaxima = PlayerPrefs.GetInt ("puntuacionmaxima", puntuacionmaxima);
		highscore.text = puntuacionmaxima.ToString ();
	}

	public void Puntos (int puntosganados) {
		puntuacion = puntuacion + puntosganados;
		contador.text = puntuacion.ToString ();
		if (puntuacion >= puntuacionmaxima) {
			puntuacionmaxima = puntuacion;
			highscore.text = puntuacionmaxima.ToString ();
			PlayerPrefs.SetInt ("puntuacionmaxima", puntuacionmaxima);
		}
	}

}
