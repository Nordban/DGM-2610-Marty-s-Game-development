using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollsionDetection : MonoBehaviour
{
    [SerializeField]
    private BossMovment boss;

    private void Start()
    {
        boss = GetComponentInParent<BossMovment>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //Debug.Log("Player found");
            boss.patrolling = false;
            boss.playerSpotted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("PlayerLost");
            boss.playerSpotted = false;
            boss.searching = true;
            
            boss.lastKnownPosition = other.transform.position;
            boss.playerLost = true;
        }
    }
}
