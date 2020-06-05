using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public List<GameObject> enemies;
    public bool watchEnemy = false;
    public int currentEnemy = 0;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject target;

    
    public PlayerMovment player;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        target = GameObject.Find("Player");
        //player = target.GetComponent<PlayerMovment>();

        //mainCamera.transform.position = player.PlayerTransform();
        mainCamera.transform.position = target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = player.PlayerTransform();
       
        if (watchEnemy == false)
        {
            mainCamera.transform.position = target.transform.position;
        }
        if (watchEnemy == true)
        {
            mainCamera.transform.position = enemies[currentEnemy].transform.position;
        }

    }
}
