using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BasicNavMeshEnemy : MonoBehaviour
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
    //public GameObject bEnemyMesh;
    public int targetWaypoint = 0;

    public GameObject waypointPrefab;
    public GameObject searchWaypoint;
    public int searchWaypointQuantity = 0;
    public List<GameObject> searchWaypoints;
    public int currentSearchWaypoint;

    public EnemySwing swingScript;
    //[SerializeField]
    //private Collider engageDistance;
    [SerializeField]
    private EnemySpawnpointManager enemySpawnpointManager;

    [SerializeField]
    private NavMeshAgent basicEnemyNavMesh;


    delegate void AIBehavior();
    [SerializeField]
    AIBehavior aIBehavior;
    // Start is called before the first frame update
    void Start()
    {
        
        basicEnemyNavMesh = GetComponent<NavMeshAgent>();

        basicEnemyNavMesh.radius = 1f;
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
        else if (searching)
        {
            aIBehavior = IAmSearching;
        }
        else
        {
            aIBehavior = Patrol;
        }

        aIBehavior();
    }

    void Patrol()
    {
        if (basicEnemyNavMesh.radius != 1)
        {
            basicEnemyNavMesh.radius = 1;
        }

        basicEnemyNavMesh.speed = .5f;
        basicEnemyNavMesh.stoppingDistance = 0;
        searchWaypointQuantity = 0;
        basicEnemyNavMesh.destination = waypoints[targetWaypoint].transform.position;
        if (Vector3.Distance(basicEnemyNavMesh.transform.position, waypoints[targetWaypoint].transform.position) < .25f)
        {
            if (targetWaypoint < waypoints.Capacity - 1)
            {
                targetWaypoint++;
            }
            else
            {
                targetWaypoint = 0;
            }
        }
    }

    void PlayerSpotted()
    {
        //this.transform.LookAt(head.transform);

        StopCoroutine("SearchTimmer");
        StopCoroutine("Waiting");
        if (searching)
        {
            searching = false;
            searchWaypointQuantity = 0;
        }
        if (backToIt)
        {
            backToIt = false;
        }
        if (searchWaypoints.Count != 0)
        {
            for (int i = 0; i < searchWaypoints.Count; i++)
            {
                Destroy(searchWaypoints[i].gameObject);
            }
            searchWaypoints.Clear();
        }
        if (Vector3.Distance(basicEnemyNavMesh.transform.position, player.transform.position) > 5f)
        {
            basicEnemyNavMesh.transform.LookAt(head.transform);
        }
        else
        {
            basicEnemyNavMesh.updateRotation = true;
        }
        basicEnemyNavMesh.radius = 1f;
        basicEnemyNavMesh.speed = 4f;
        basicEnemyNavMesh.destination = player.transform.position;
        basicEnemyNavMesh.stoppingDistance = .4f;
        if (Vector3.Distance(basicEnemyNavMesh.transform.position, player.transform.position) < 1f)
        {
            swingScript.Attack();


            transform.LookAt(head.transform);
        }
    }

    void IAmSearching()
    {
        if (playerLost)
        {
            basicEnemyNavMesh.destination = lastKnownPosition;
            this.transform.LookAt(lastKnownPosition);
            playerLost = false;
            pause = false;
        }

        basicEnemyNavMesh.speed = 2f;
        basicEnemyNavMesh.stoppingDistance = 0;

        if (basicEnemyNavMesh.remainingDistance < 2)
        {
            //Debug.Log("starting searchTimmer");
            StartCoroutine("SearchTimmer");

            //Realistic AI search behavior : use the CoRoutine to 
            while (searchWaypointQuantity <= 2)
            {
                searchWaypoint = Instantiate(waypointPrefab, new Vector3(basicEnemyNavMesh.transform.position.x + Random.Range(-3, 3), 0, basicEnemyNavMesh.transform.position.z + Random.Range(-3, 3)), Quaternion.identity);
                searchWaypoints.Add(searchWaypoint);
                searchWaypointQuantity++;
            }
            Search();
        }
    }

    void Search()
    {
        if (!pause)
        {
            if (basicEnemyNavMesh.remainingDistance < .25f)
            {
                pause = true;
                StartCoroutine("Waiting");
            }
        }
        else
        {
            return;
        }
    }

    private IEnumerator SearchTimmer()
    {
        yield return new WaitForSeconds(12f);
        backToIt = true;
        if (backToIt)
        {
            StopCoroutine("Waiting");
            searching = false;
            patrolling = true;
            aIBehavior = Patrol;
            //playerLost = false;
            backToIt = false;
            if (searchWaypoints.Count != 0)
            {
                for (int i = 0; i < searchWaypoints.Count; i++)
                {
                    Destroy(searchWaypoints[i].gameObject);
                }
                searchWaypoints.Clear();
            }
            StopCoroutine("SearchTimmer");
        }
    }

    private IEnumerator Waiting()
    {
        //Debug.Log("I should be paused");
        yield return new WaitForSeconds(1f);
        int lastSearchWaypoint = currentSearchWaypoint;

        currentSearchWaypoint = Random.Range(0, 2);
        if (currentSearchWaypoint == lastSearchWaypoint && currentSearchWaypoint != 2)
        {
            currentSearchWaypoint++;
        }
        else
        {
            currentSearchWaypoint = 0;
        }
        basicEnemyNavMesh.destination = searchWaypoints[currentSearchWaypoint].transform.position;
        pause = false;
    }

    
}
