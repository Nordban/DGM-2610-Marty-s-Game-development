using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    //public List<GameObject> enemies;
    //public bool watchEnemy = false;
    //public int currentEnemy = 0;
    public GameObject target;
    [SerializeField]
    private Camera mainCamera;
    

    
    public SimpleMove player;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        //target = GameObject.Find("Player");
        

        
        mainCamera.transform.position = target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = target.transform.position;

        //if (watchEnemy == false)
        //{
        //    mainCamera.transform.position = target.transform.position;
        //}
        //if (watchEnemy == true)
        //{
        //    mainCamera.transform.position = enemies[currentEnemy].transform.position;
        //}
        //if (target == null)
        //{
        //    target = GameObject.Find("Player");
        //}
    }
}
