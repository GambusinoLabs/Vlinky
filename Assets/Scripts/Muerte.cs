using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se encarga de controlar el sistema de muerte del personaje. Debe asignarse al personaje.
public class Muerte : MonoBehaviour
{

    // properties
    public Animator blinkyAnim;
    public Retry reiniciar;  // Debe asignarse un objeto con el script restart.
    public float Y;
    public bool godMode = false;
    Blinky3 blinky;

    // methods
    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (godMode == true && IsGelatinaTag(col.tag))
        {
            Debug.Log("NO PUEDO MORIR");
            if (col.tag == "Gelatina")
                Destroy(col.gameObject.transform.parent.gameObject);
            else
                Destroy(col.gameObject);
        }
        else
        {
            blinky = GetComponent<Blinky3>();
            // Provoca que, si el objeto que lleva este script entra en contacto con una gelatina cualquiera, sea destruido y la escena se reinicie.
            if (col != null && (col.gameObject.tag == "Gelatina" || col.gameObject.tag == "GelatinaReparadora" || col.gameObject.tag == "GelatinaTotal"))
            {
                blinky.enabled = !blinky.enabled;
                Destroy(col.gameObject);
                Destroy(col.gameObject.transform.parent.gameObject);
                blinkyAnim.SetBool("Muere", true);
                GetComponent<Collider2D>().isTrigger = true;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                yield return new WaitForSecondsRealtime(0.1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, Y / 3);
                yield return new WaitForSecondsRealtime(0.1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                yield return new WaitForSecondsRealtime(0.1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Y / 2);
                yield return new WaitForSecondsRealtime(2);
                Destroy(gameObject);
                reiniciar.RetryGame();
            }
        }
    }

    bool IsGelatinaTag(string tag)
    {
        if (tag == "GelatinaTotal" || tag == "Gelatina" || tag == "GelatinaReparadora" || tag == "Enemigo")
            return true;
        else return false;
    }

}
