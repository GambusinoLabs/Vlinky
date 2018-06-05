using UnityEngine;
using UnityEngine.Events;

public class KeyboardInput : MonoBehaviour
{
    public UnityEvent LeftKeyDown, LeftKeyUp, RightKeyDown, RightKeyUp, UpKeyDown;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            LeftKeyDown.Invoke();
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            LeftKeyUp.Invoke();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            RightKeyDown.Invoke();
        if (Input.GetKeyUp(KeyCode.RightArrow))
            RightKeyUp.Invoke();
        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpKeyDown.Invoke();
    }
}
