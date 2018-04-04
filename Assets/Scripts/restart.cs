using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //IMPORTANTE PARA PODER MODIFICAR ESCENAS
// Provoca que se reinicie la escena actual. Debe asignarse a un objeto vacío.
public class restart : MonoBehaviour 
{

	// methods
	public void ResetearEscena() 
	{
		
		// Reinicia la escena. 
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		// Reestablece la velocidad a la que se mueve el tiempo.
			Time.timeScale = 1;
	
	}

}
