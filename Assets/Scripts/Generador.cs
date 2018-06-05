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

    [Space(40)]
    public bool usarCurvas = true;
    public AnimationCurve tiempoEntreSpawnCurve, factorDeVelocidadCurve;
    //public AnimationCurve tiempoRandomCurve, factorDeVelocidadRandomCurve;

    private Transform m_dynamicTransform;
    public Transform DynamicTransform
    {
        get
        {
            if (m_dynamicTransform != null)
                return m_dynamicTransform;
            else
            {
                GameObject dynamicGameObject = GameObject.Find("_Dynamic");
                if (dynamicGameObject == null)
                    dynamicGameObject = new GameObject("_Dynamic");
                m_dynamicTransform = dynamicGameObject.transform;
                return m_dynamicTransform;
            }
        }
    }

    void Start()
    {
        Invoke("Spawn", esperaInicial);
        if (!usarCurvas)
            this.enabled = false;
    }

    void Update()
    {
        // Solo se llamará si se usa la curva
        tiempoEntreSpawn = tiempoEntreSpawnCurve.Evaluate(Time.timeSinceLevelLoad);
        //tiempoRandom = tiempoRandomCurve.Evaluate(Time.timeSinceLevelLoad);
        tiempoRandom = tiempoEntreSpawn / 2.5f;

        factorDeVelocidad = factorDeVelocidadCurve.Evaluate(Time.timeSinceLevelLoad);
        //factorDeVelocidadRandom = factorDeVelocidadRandomCurve.Evaluate(Time.timeSinceLevelLoad);
        factorDeVelocidadRandom = factorDeVelocidad / 2.5f;
    }

    private void Spawn()
    {
        GameObject newGelatine = Instantiate(prefabASpawnear, DynamicTransform);
        newGelatine.transform.position = transform.position + Random.Range(-amplitudSpawn, +amplitudSpawn) * Vector3.right;
        GelatinaForce gelatinaSpeedController;
        gelatinaSpeedController = newGelatine.GetComponentInChildren<GelatinaForce>();
        if (gelatinaSpeedController == null)
            gelatinaSpeedController = newGelatine.GetComponent<GelatinaForce>();
        gelatinaSpeedController.velocidad *= Random.Range(factorDeVelocidad - factorDeVelocidadRandom, factorDeVelocidad + factorDeVelocidadRandom);
        Invoke("Spawn", Random.Range(tiempoEntreSpawn - tiempoRandom, tiempoEntreSpawn + tiempoRandom));
    }
}
