using UnityEngine;
using UnityEngine.Events;

public class UserInputBehaviour : MonoBehaviour
{
    public KeyCode button;
    public UnityEvent keyEvent;
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            keyEvent.Invoke();
           
        }
    }
}
