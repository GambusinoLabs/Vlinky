using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //IMPORTANTE PARA PODER MODIFICAR ESCENAS

public class restart : MonoBehaviour {


	// Update is called once per frame
	public void ResetearEscena () {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			Time.timeScale = 1;
	}
}
