using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// Se encarga de inicializar la escena del juego, debe ser llamado desde un botón u otro script.
public class Iniciar : MonoBehaviour 
{
	// methods
	public void Jugar() 
	{
		
       SceneManager.LoadScene(1);

    }

}
