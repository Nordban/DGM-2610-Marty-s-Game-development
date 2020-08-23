using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpeedChange : MonoBehaviour
{
    public GameObject character;
    public SimpleMove simpleMoveScpt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Sand Area Triggered ");
            simpleMoveScpt = character.GetComponent<SimpleMove>();
            simpleMoveScpt.speedValue = 1.17f;
            simpleMoveScpt.runValue = 2.67f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            simpleMoveScpt.speedValue = 1.75f;
            simpleMoveScpt.runValue = 4f;
        }
    }

}
