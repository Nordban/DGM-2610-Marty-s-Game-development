using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventWithPause : MonoBehaviour
{
    public float enterHoldTime, exitHoldTime = 0.1f;
    public WaitForSeconds enterWaitObj, exitWaitObj;

    public UnityEvent triggerEnterEventPause, triggerExitEvent,
        collisionEnterEvent, collisionExitEvent;

    private void Awake()
    {
        enterWaitObj = new WaitForSeconds(enterHoldTime);
        exitWaitObj = new WaitForSeconds(exitHoldTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return enterWaitObj;
        Time.timeScale = 0;
        triggerEnterEventPause.Invoke();
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return exitWaitObj;
        triggerExitEvent.Invoke();
    }

    private IEnumerator OnCollisionEnter(Collision other)
    {
        yield return enterWaitObj;
        collisionEnterEvent.Invoke();
    }

    private IEnumerator OnCollisionExit(Collision other)
    {
        yield return exitWaitObj;
        collisionExitEvent.Invoke();
    }
}
