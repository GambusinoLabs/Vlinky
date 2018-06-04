using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de controlar el sistema de tiempo del juego, acelerándolo o ralentizándolo.
public class TimeManage : MonoBehaviour
{

    // fields
    bool pausado = false;                       // Define si el juego está pausado o no.
    float multiplo = 1;
    float velocidad;                            // Se usa para guardar la velocidad cuando se pausa el juego.

    public void Pause()
    {

        // Provoca que el tiempo en la escena se detenga y se guarde la velocidad que tenia antes de la pausa.
        pausado = true;
        velocidad = Time.timeScale;
        Time.timeScale = 0;

    }


    public void Resume()
    {

        // Provoca que la velocidad del tiempo en la escena vuelva a su estado antes de pausarla.
        Time.timeScale = velocidad;
        pausado = false;

    }

    public void Double()
    {

        // Provoca que la velocidad del tiempo en la escena pase a ser el doble de la actual.
        multiplo = multiplo * 2;

    }

    public void Half()
    {

        // Provoca que la velocidad del tiempo en la escena pase a ser la mitad de la actual.
        multiplo = multiplo / 2;

    }

}
