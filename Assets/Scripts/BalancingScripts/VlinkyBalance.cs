using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VlinkyBalance : MonoBehaviour
{

    public Blinky3 vlinkyController;
    public AnimationCurve vlinkySpeedCurve;
    public AnimationCurve vlinkyCooldownCurve;

    public bool valoresFinales = false;

    void Start()
    {
        if (valoresFinales)
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
    }
}
