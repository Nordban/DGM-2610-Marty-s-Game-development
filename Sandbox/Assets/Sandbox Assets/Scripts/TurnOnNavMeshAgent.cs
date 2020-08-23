using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnOnNavMeshAgent : MonoBehaviour
{
    public NavMeshAgent playerPlaceholder;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPlaceholder.enabled = true;
        }
    }
}
