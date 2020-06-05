using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInputWUnpause : MonoBehaviour
{
    public KeyCode button;
    public UnityEvent keyEvent;
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            keyEvent.Invoke();
            Time.timeScale = 1;
        }
    }
}
