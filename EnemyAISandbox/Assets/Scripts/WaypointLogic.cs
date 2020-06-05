using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointLogic : MonoBehaviour
{
    private Collider myCollider;
    
    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log("Enemy " + other.name + "is here.");
            //update waypoint number in BasicEnemyAI script
            other.gameObject.GetComponent<BasicEnemyAI>().currentWaypointNumber++;
        }
    }
}
