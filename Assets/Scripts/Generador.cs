using UnityEngine;
using System.Collections;
// Se encarga de generar gelatinas cada tiempo determinado en una posición aleatoria de un rango determinado.
public class Generador : MonoBehaviour 
{
	
	// fields
	float secondsCounter = 0;
	float secondsCounter2 = 0;
	float secondsCounter3 = 0;
	float secondsToCount;				
	float secondsToCount2;				
	float secondsToCount3;			
	int number = 0;
	Vector3 rangoGenerador; 			// Determinará la posición base en la que se generarán los objetos.

	// properties
	public AnimationCurve curva; 		// Determina cada cuanto tiempo se genera un nuevo objeto del primer tipo. 
	public AnimationCurve curva2;		// Determina cada cuanto tiempo se genera un nuevo objeto del segundo tipo.
	public AnimationCurve curva3;		// Determina cada cuanto tiempo se genera un nuevo objeto del tercer tipo.
	public GameObject gelatina;			// Determina el primer tipo de objeto a instanciar.
	public GameObject gelatina2;		// Determina el segundo tipo de objeto a instanciar.
	public GameObject gelatina3;		// Determina el tercer tipo de objeto a instanciar.
	public int variable = 10;			// Determinará el rango de distancia en ambas direcciones en el que se generarán los objetos.

	// methods
	void Start() 
	{
		
		// Provoca que se genere un primer objeto nada más iniciar la escena.
			GenerarGelatina();

	}

	void Update() 
	{
			
		secondsToCount = curva.Evaluate(Time.timeSinceLevelLoad);
		secondsToCount2 = curva2.Evaluate(Time.timeSinceLevelLoad);
		secondsToCount3 = curva3.Evaluate(Time.timeSinceLevelLoad);
		secondsCounter += Time.deltaTime;
		// Si ha pasado tanto tiempo como indica la variable secondsToCount, se genera una gelatina.
		if (secondsCounter >= secondsToCount) 
		{
			secondsCounter = 0;
			number++;
			GenerarGelatina();
		}

		secondsCounter2 += (Time.deltaTime / 2);
		// Si ha pasado tanto tiempo como indica la variable secondsToCount2, se genera una gelatina.
		if ((Time.time >= 30f) && (secondsCounter2 >= secondsToCount2)) 
		{
			secondsCounter2 = 0;
			number++;
			GenerarGelatina2();
		}

		secondsCounter3 += Time.deltaTime;
		if (secondsCounter3 >= secondsToCount3) 
		{
			secondsCounter3 = 0;
			number++;
			GenerarGelatina3();
		}

	}

	void GenerarGelatina() 
	{
		
		// Determina un rango aleatorio, partiendo de la posición del objeto que lleva este script, añadiendole una distancia igual a variable en cada dirección.
		rangoGenerador = new Vector3(Random.Range(transform.position.x - variable, transform.position.x + variable), transform.position.y, transform.position.z);
		// Si hay un objeto asignado en el inspector, se genera en la posicion determinada anteriormente, si no, el Debugger nos informa de que no está asignado.
		if (gelatina != null) 
		{
			Instantiate(gelatina, rangoGenerador, transform.rotation);
		} 
		else 
		{
			Debug.Log("GenerarGelatina: ¡No has asignado el prefab en el inspector! (O eso parece, porque el GameObject gelatina es = null)");
		}

	}

	void GenerarGelatina2()
	{
		
		// Determina un rango aleatorio, partiendo de la posición del objeto que lleva este script, añadiendole una distancia igual a variable en cada dirección.
		rangoGenerador = new Vector3 (Random.Range (transform.position.x - variable, transform.position.x + variable), transform.position.y, transform.position.z);
		// Si hay un objeto asignado en el inspector, se genera en la posicion determinada anteriormente, si no, el Debugger nos informa de que no está asignado.
		if (gelatina2 != null) {
			Instantiate (gelatina2, rangoGenerador, transform.rotation);
		} else {
			Debug.Log ("GenerarGelatina: ¡No has asignado el prefab en el inspector! (O eso parece, porque el GameObject gelatina es = null)");
		}
	}

	void GenerarGelatina3() 
		{

		// Determina un rango aleatorio, partiendo de la posición del objeto que lleva este script, añadiendole una distancia igual a variable en cada dirección.
		rangoGenerador = new Vector3(Random.Range (transform.position.x - variable, transform.position.x + variable), transform.position.y, transform.position.z);
		// Si hay un objeto asignado en el inspector, se genera en la posicion determinada anteriormente, si no, el Debugger nos informa de que no está asignado.
		if (gelatina3 != null) 
		{
			Instantiate(gelatina3, rangoGenerador, transform.rotation);
		} 
		else 
		{
			Debug.Log("GenerarGelatina: ¡No has asignado el prefab en el inspector! (O eso parece, porque el GameObject gelatina es = null)");
		}

	}

}
	