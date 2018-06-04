using UnityEngine;
using System.Collections;
// Se encarga de generar gelatinas cada tiempo determinado en una posición aleatoria de un rango determinado.
public class Generador : MonoBehaviour
{
    public GameObject prefabASpawnear;         // Determina el primer tipo de objeto a instanciar.
    public float amplitudSpawn = 7.35f;            // Determinará el rango de distancia en ambas direcciones en el que se generarán los objetos.

    [Space(20)]
    public float esperaInicial = 5.0f;
    public float tiempoEntreSpawn = 5.0f;
    public float tiempoRandom = 2.0f;

    [Space(20)]
    public float factorDeVelocidad = 1.0f;
    public float factorDeVelocidadRandom = 0.1f;

    private Transform dynamicTransform;

    void Start()
    {
        dynamicTransform = GameObject.FindGameObjectWithTag("Dynamic").transform;
        Invoke("Spawn", esperaInicial);
    }

    private void Spawn()
    {
        GameObject newGelatine = Instantiate(prefabASpawnear, dynamicTransform);
        newGelatine.transform.position = transform.position + Random.Range(-amplitudSpawn, +amplitudSpawn) * Vector3.right;
        GelatinaForce gelatinaSpeedController;
        gelatinaSpeedController = newGelatine.GetComponentInChildren<GelatinaForce>();
        if (gelatinaSpeedController == null)
            gelatinaSpeedController = newGelatine.GetComponent<GelatinaForce>();
        gelatinaSpeedController.velocidad *= Random.Range(factorDeVelocidad - factorDeVelocidadRandom, factorDeVelocidad + factorDeVelocidadRandom);
        Invoke("Spawn", Random.Range(tiempoEntreSpawn - tiempoRandom, tiempoEntreSpawn + tiempoRandom));
    }
}
