using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public Collider playerDetectionCollider;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<GameObject>();

    }

    private void OnTriggerEnter(Collider collider)
    {
        

        
    }
}
