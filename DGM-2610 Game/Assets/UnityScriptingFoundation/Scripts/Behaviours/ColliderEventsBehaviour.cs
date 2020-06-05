using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventsBehaviour : MonoBehaviour
{
    public float enterHoldTime, exitHoldTime = 0.1f;
    public WaitForSeconds enterWaitObj, exitWaitObj;

    public UnityEvent triggerEnterEvent, triggerExitEvent, 
        collisionEnterEvent, collisionExitEvent, triggerEnterEventPause;

    private void Awake()
    {
        enterWaitObj = new WaitForSeconds(enterHoldTime);
        exitWaitObj = new WaitForSeconds(exitHoldTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return enterWaitObj;
        triggerEnterEvent.Invoke();
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