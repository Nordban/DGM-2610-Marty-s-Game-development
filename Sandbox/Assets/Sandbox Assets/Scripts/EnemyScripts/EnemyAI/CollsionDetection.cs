using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetection : MonoBehaviour
{
    [SerializeField]
    private BasicNavMeshEnemy basicNavMeshEnemy;

    private void Start()
    {
        basicNavMeshEnemy = GetComponentInParent<BasicNavMeshEnemy>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //Debug.Log("Player found");
            basicNavMeshEnemy.patrolling = false;
            basicNavMeshEnemy.playerSpotted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("PlayerLost");
            basicNavMeshEnemy.playerSpotted = false;
            basicNavMeshEnemy.searching = true;
            
            basicNavMeshEnemy.lastKnownPosition = other.transform.position;
            basicNavMeshEnemy.playerLost = true;
        }
    }
}
