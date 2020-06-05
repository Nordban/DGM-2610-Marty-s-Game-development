using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPartolling : MonoBehaviour
{
    public GameObject[] waypoints = new GameObject[4];


    private NavMeshAgent agent;
    private int waypoint = 0;
    // Start is called before the first frame update
    void Start()
    {
               
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[waypoint].transform.position;
    }

    //Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
            if (waypoint != waypoints.Length-1)
            {
                waypoint++;

            }
            else
            { waypoint = 0; }


        agent.SetDestination(waypoints[waypoint].transform.position); 

    }        
}
