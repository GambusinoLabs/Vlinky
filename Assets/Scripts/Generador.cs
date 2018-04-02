using UnityEngine;
using System.Collections;
// Se encarga de generar gelatinas cada tiempo determinado en una posición aleatoria de un rango determinado.
public class Generador : MonoBehaviour 
{
	// fields
	float secondsCounter = 0;
	GameObject gelatina_nueva;
	int number = 0;
	Vector3 rangoGenerador; 			//Determinará la posición base en la que se generarán los objetos.

	// properties
	public float secondsToCount = 1;	// Determina cada cuanto tiempo se genera un nuevo objeto.
	public GameObject gelatina;			// Determina el objeto a instanciar.
	public int variable = 10;			//Determinará el rango de distancia en ambas direcciones en el que se generarán los objetos.

	// methods
	void Start() 
	{
		
		//Provoca que se genere un primer objeto nada más iniciar la escena
			GenerarGelatina();

	}

	void Update() 
	{
		
		secondsCounter += Time.deltaTime;
		// Si ha pasado tanto tiempo como indica la variable secondsToCount, se genera una gelatina.
		if (secondsCounter >= secondsToCount) 
		{
			secondsCounter = 0;
			number++;
			GenerarGelatina();
		}

	}

	void GenerarGelatina() 
	{
		
		// Determina un rango aleatorio, partiendo de la posición del objeto que lleva este script, añadiendole una distancia igual a variable en cada dirección.
		rangoGenerador = new Vector3 (Random.Range (transform.position.x - variable, transform.position.x + variable), transform.position.y, transform.position.z);
		//Si hay un objeto asignado en el inspector, se genera en la posicion determinada anteriormente, si no, el Debugger nos informa de que no está asignado
		if (gelatina != null) 
		{
			gelatina_nueva = (GameObject)Instantiate(gelatina, rangoGenerador, transform.rotation);
		} 
		else 
		{
			Debug.Log("GenerarGelatina: ¡No has asignado el prefab en el inspector! (O eso parece, porque el GameObject gelatina es = null)");
		}

	}

}
	