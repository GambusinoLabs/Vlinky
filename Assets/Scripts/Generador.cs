using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	public GameObject gelatina;
	private GameObject gelatina_nueva;
	private int number = 0;
	private float secondsCounter = 0;
	public float secondsToCount = 1;
	public static bool generar = true;
	Vector3 genero;
	public int variable = 10;

	void Start() {
		if (generar == true) 
			GenerarGelatina ();
		}

	void Update() {
		secondsCounter += Time.deltaTime;

		if (generar == true && secondsCounter >= secondsToCount) {
			
			secondsCounter = 0;
			number++;
			GenerarGelatina ();
		}

	}

	void GenerarGelatina() {
		genero = new Vector3 (Random.Range (transform.position.x - variable, transform.position.x + variable), transform.position.y, transform.position.z);
        if (gelatina != null)
			gelatina_nueva = (GameObject)Instantiate(gelatina, genero, transform.rotation);
        else
            Debug.Log("GenerarGelatina: ¡No has asignado el prefab en el inspector! (O eso parece, porque el GameObject gelatina es = null)");
	}
}
	