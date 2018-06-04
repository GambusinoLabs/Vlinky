using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VlinkyBalance : MonoBehaviour
{

    public Blinky3 vlinkyController;
    public AnimationCurve vlinkySpeedCurve;
    public AnimationCurve vlinkyCooldownCurve;

    public bool debug = false;

    void Start()
    {
        if (debug)
        {
            vlinkyController.velocidadMovimiento = vlinkySpeedCurve.Evaluate(999f);
            vlinkyController.shotCooldown = vlinkyCooldownCurve.Evaluate(999f);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vlinkyController.velocidadMovimiento = vlinkySpeedCurve.Evaluate(Time.timeSinceLevelLoad);
        vlinkyController.shotCooldown = vlinkyCooldownCurve.Evaluate(Time.timeSinceLevelLoad);

        Debug.Log("Velocidad: " + vlinkyController.velocidadMovimiento + " --- Cooldown: " + vlinkyController.shotCooldown);
    }
}
