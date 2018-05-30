using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
// Se encarga de cambiar de escena en el juego, debe ser llamado desde un botón u otro script.
public class SceneManagement : MonoBehaviour
{

    [HideInInspector]
    public static bool isChangingScene = false;

    void Start()
    {
        EditorApplication.playModeStateChanged += HandleOnPlayModeChanged;
        isChangingScene = false;
    }

    // methods
    public void Jugar()
    {

        isChangingScene = true;
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {

        isChangingScene = true;
        SceneManager.LoadScene(0);

    }


    void HandleOnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
            isChangingScene = true;
    }

}
