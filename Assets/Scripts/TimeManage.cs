using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour {

	void Update () {
		Time.timeScale = Time.timeScale + (Time.deltaTime * 0.01f);
	
		print (Time.timeScale);
	}

	public void Pause() {
		Time.timeScale = 0;
	}

	public void Resume() {
		Time.timeScale = 1;
	}

	public void Double () {
		Time.timeScale = 2;
	}

	public void Half () {
		Time.timeScale = 0.5f;
	}
		
}
