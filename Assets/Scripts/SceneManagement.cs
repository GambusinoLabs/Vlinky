using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// Se encarga de cambiar de escena en el juego, debe ser llamado desde un botón u otro script.
public class SceneManagement : MonoBehaviour 
{
	
	// methods
	public void Jugar() 
	{
		
       SceneManager.LoadScene(1);

    }

	public void Menu()
	{

		SceneManager.LoadScene (0);

	}

}
