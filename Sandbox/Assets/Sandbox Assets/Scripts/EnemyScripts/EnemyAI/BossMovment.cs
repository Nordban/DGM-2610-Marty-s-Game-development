using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossMovment : MonoBehaviour
{

    public bool playerSpotted = false;
    public bool playerLost = false;
    public bool searching = false;
    public bool patrolling = true;
    public bool pause = false;
    public bool backToIt = false;
    public Vector3 lastKnownPosition;
    public List<GameObject> waypoints;
    public GameObject player;
    public GameObject head;
  

   

    public BossSwing swingScript;
  

    [SerializeField]
    private NavMeshAgent BossNavMesh;


    delegate void AIBehavior();
    [SerializeField]
    AIBehavior aIBehavior;
    // Start is called before the first frame update
    void Start()
    {
        
        BossNavMesh = GetComponent<NavMeshAgent>();

        BossNavMesh.radius = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        head = GameObject.FindGameObjectWithTag("Head");
        //var enemySpawnpointManagerObject = GameObject.Find("EnemySpawnpointManager");
        //enemySpawnpointManager = enemySpawnpointManagerObject.GetComponent<EnemySpawnpointManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerSpotted)
        {
            aIBehavior = PlayerSpotted;
        }
        else
        {
            aIBehavior = Patrol;
        }

        aIBehavior();
    }

    void Patrol()
    {
        this.transform.LookAt(lastKnownPosition);
    }

    void PlayerSpotted()
    {
        //this.transform.LookAt(head.transform);

        if (Vector3.Distance(BossNavMesh.transform.position, player.transform.position) > 5f)
        {
            BossNavMesh.transform.LookAt(player.transform);
        }
        else
        {
            BossNavMesh.updateRotation = true;
        }
        BossNavMesh.radius = 1.2f;
        BossNavMesh.speed = 2f;
        BossNavMesh.destination = player.transform.position;
        BossNavMesh.stoppingDistance = .6f;
        if (Vector3.Distance(BossNavMesh.transform.position, player.transform.position) < 2f)
        {
            swingScript.Attack();


            transform.LookAt(head.transform);
        }
    }
   
}
