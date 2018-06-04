using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Controla el sonido creando una lista de sonidos necesarios en la escena para instanciarlos desde script mediante Sound.ReproducirSonido(numero).
public class Sound : MonoBehaviour {

	AudioSource aSource;
	[SerializeField]
	List<AudioClip> sonidos;
	void Start () {
		aSource = GetComponent<AudioSource> ();
	}

	public void ReproducirSonido(int nsonido){
		aSource.clip = sonidos [nsonido];
		aSource.Play ();
	}

	void Update () {
		}
	}
