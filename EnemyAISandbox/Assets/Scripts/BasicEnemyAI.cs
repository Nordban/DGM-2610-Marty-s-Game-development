using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
public class BasicEnemyAI : MonoBehaviour
{

    public float moveSpeed = 7;
    public float approachSpeed = 4;
    public float chaseSpeed = 10;
    public float searchSpeed = 4;
    public float stopped = 0;
    public float timer = 0;
    public float lookingSpeed = 3;

    public bool playerSpotted = false;
    public bool playerLost = false;
    public bool searching = false;

    public GameObject waypointPrefab;
    public GameObject currentWaypoint;
    public int currentWaypointNumber = 0;
    
    public List<GameObject> waypoints;

    
    public GameObject searchWaypoint;
    public int searchWaypointQuantity = 0;
    public List<GameObject> searchWaypoints;
    public int currentSearchWaypoint;
    //public int currentSearchWaypointNumber = 0;

    [SerializeField]
    private GameObject player;
    private GameObject enemy;
    [SerializeField]
    private Collider engageDistance;
    [SerializeField]
    private Vector3 lastKnownPosition;


    delegate void AIBehavior();
    [SerializeField]
    AIBehavior aIBehavior;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject;
        engageDistance = enemy.GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpotted)
        {
            aIBehavior = IAmChasing;
        }
        else if (searching)
        {
            aIBehavior = IAmSearching;
        }
        else
        {
            aIBehavior = IAmPatroling;
        }

        aIBehavior();
    }

    void IAmPatroling()
    {
        if (currentWaypointNumber <= waypoints.Count - 1)
        {
            currentWaypoint = waypoints[currentWaypointNumber];
        }
        else
        {
            currentWaypointNumber = 0;
        }
        enemy.transform.LookAt(currentWaypoint.transform);
        if (Vector3.Distance(enemy.transform.position, waypoints[currentWaypointNumber].transform.position) >= 7)
        {
            enemy.transform.localPosition += enemy.transform.forward * moveSpeed * Time.deltaTime;

        }
        else if (Vector3.Distance(enemy.transform.position, waypoints[currentWaypointNumber].transform.position) < 7)
        {
            enemy.transform.localPosition += enemy.transform.forward * approachSpeed * Time.deltaTime;
        }
    }
    void IAmChasing()
    {
        enemy.transform.LookAt(player.transform);
        if (Vector3.Distance(enemy.transform.position, player.transform.position) > 2)
        {
            //Debug.Log("normal chase speed" + chaseSpeed);
            enemy.transform.localPosition += enemy.transform.forward * chaseSpeed * Time.deltaTime;
        }
        if (Vector3.Distance(enemy.transform.position, player.transform.position) <= 2)
        {
           // Debug.Log("caught you");
            enemy.transform.localPosition += enemy.transform.forward * stopped * Time.deltaTime;
        }

    }

    void IAmSearching()
    {
        if (!playerLost)
        {
            enemy.transform.LookAt(lastKnownPosition);
            enemy.transform.localPosition += enemy.transform.forward * searchSpeed * Time.deltaTime;
        }
        if (Vector3.Distance(enemy.transform.position, lastKnownPosition) < 1)
        {
            enemy.transform.localPosition += enemy.transform.forward * stopped * Time.deltaTime;
           // Debug.Log("starting searchTimmer");
            StartCoroutine(SearchTimmer());

            //Realistic AI search behavior : use the CoRoutine to 
            while (searchWaypointQuantity <= 2)
            {
                searchWaypoint = Instantiate(waypointPrefab, new Vector3(enemy.transform.localPosition.x + Random.Range(-5, 5), 0, enemy.transform.localPosition.z + Random.Range(-5, 5)), Quaternion.identity);
                searchWaypoints.Add(searchWaypoint);
                searchWaypointQuantity++;
            }

            //enemy.transform.LookAt(searchWaypoints[currentSearchWaypoint].transform.position);


            //

            ////while (timer < 3)
            ////{
            ////    timer += timer * Time.deltaTime;
            ////    Debug.Log(timer);
            ////}
            //if (currentSearchWaypoint < searchWaypoints.Count)
            //{
            //    currentSearchWaypoint++;
            //}
            //else
            //{
            //    currentSearchWaypoint = 0;
            //}
            //timer = 0;
            //enemy.transform.LookAt(searchWaypoints[currentSearchWaypoint].transform.position);
            //if (Vector3.Distance(enemy.transform.position, searchWaypoints[currentSearchWaypoint].transform.position) > .5f)
            //{
            //    enemy.transform.localPosition += enemy.transform.forward * lookingSpeed * Time.deltaTime;
            //    //Debug.Log("trying to move to search waypoint # " + currentSearchWaypoint);

            //}
            //if (Vector3.Distance(enemy.transform.position, searchWaypoints[currentSearchWaypoint].transform.position) < .5f)
            //{
            //    enemy.transform.localPosition += enemy.transform.position * stopped * Time.deltaTime;
            //}



            //enemy.transform.LookAt(lastKnownPosition);
            //if (Vector3.Distance(enemy.transform.position, lastKnownPosition) > .5f)
            //{
            //    enemy.transform.localPosition += enemy.transform.forward * lookingSpeed * Time.deltaTime;
            //    Debug.Log("trying to move to last known position");
            //}





        }
    }  
    private IEnumerator SearchTimmer()
    {

        playerLost = true;
        //var hold = 10;
        //while (hold < 0)
        //{
        //    yield return new WaitForFixedUpdate();
        //    //work
        //    hold--;
        //}



        yield return new WaitForSeconds(15);
        //Debug.Log("Coruoting Ended");
        if (playerLost)
        {
            searching = false;
            aIBehavior = IAmPatroling;
            //Debug.Log("changing Aibehavior" + aIBehavior);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            playerSpotted = true;
            playerLost = false;
            searching = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            searching = true;
            playerSpotted = false;
            lastKnownPosition = player.transform.position;
        }
    }
}
