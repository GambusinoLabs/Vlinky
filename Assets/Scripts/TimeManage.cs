using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de controlar el sistema de tiempo del juego, acelerándolo o ralentizándolo.
public class TimeManage : MonoBehaviour 
{
	
	// fields
	float velocidad;

	// methods
	void Update() 
	{
		
		// Provoca que la velocidad del tiempo aumente gradualmente al avanzar la escena.
		Time.timeScale = Time.timeScale + (Time.deltaTime * 0.01f);

	}

	public void Pause() 
	{
		
		// Provoca que el tiempo en la escena se detenga y se guarde la velocidad que tenia antes de la pausa.
		velocidad = Time.timeScale;
		Time.timeScale = 0;

	}


	public void Resume() 
	{
		
		// Provoca que la velocidad del tiempo en la escena vuelva a su estado antes de pausarla.
		Time.timeScale = velocidad;

	}
		
	public void Double() 
	{
		
		// Provoca que la velocidad del tiempo en la escena pase a ser el doble de la actual.
		Time.timeScale = Time.timeScale * 2;

	}

	public void Half() 
	{
		
		// Provoca que la velocidad del tiempo en la escena pase a ser la mitad de la actual.
		Time.timeScale = Time.timeScale / 2;

	}
		
}
