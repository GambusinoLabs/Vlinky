using UnityEngine;
using System.Collections;

public class GelatinaForce : MonoBehaviour {
	private Rigidbody2D rb;
	public int TiempoDestruccion = 10;
	public int vel_minima_Y = 400;
	public int vel_maxima_Y = 600;
	public int vel_minima_X = 0;
	public int vel_maxima_X = 0;
    public int vel_minima_Z = 0;
    public int vel_maxima_Z = 0;
	public int mini_impulsos_x = 50;
	public int mini_impulsos_y = 50;
    public int mini_impulsos_z = 50;
	private int number = 0;
	private float secondsCounter = 0;
	public float tiempo_mini_impulsos = 10;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector3(Random.Range(vel_minima_X,vel_maxima_X), Random.Range(vel_minima_Y,vel_maxima_Y), Random.Range(vel_minima_Z, vel_maxima_Z)));
	}

	void Update () {
		secondsCounter += Time.deltaTime;
		if (secondsCounter >= tiempo_mini_impulsos) {
			secondsCounter = 0;
			number++;
			rb.AddForce (new Vector3 (mini_impulsos_x, mini_impulsos_y, mini_impulsos_z));
		}
	}
}