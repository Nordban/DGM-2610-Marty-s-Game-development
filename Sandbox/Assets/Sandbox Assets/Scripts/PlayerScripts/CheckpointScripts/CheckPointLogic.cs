using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLogic : MonoBehaviour
{

    [SerializeField]
    private CheckpointManager cpManager;

    private void Start()
    {
        cpManager = GetComponentInParent<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            cpManager.currentCheckpoint = this.gameObject.transform.position;
        }
    }
}
