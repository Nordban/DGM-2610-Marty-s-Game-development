using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RootBridgeScript : MonoBehaviour
{
    //public GameObject rootBridgePrefab;
    public List<GameObject> roots;
    public float bridgeLength;
    public List<GameObject> barriers;
    [SerializeField]
    private bool canBuild = false;
    private bool hasBeenBuilt = false;

    // Update is called once per frame
    void Update()
    {
        BuildBridge();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player is here");
            canBuild = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBuild = false;
        }
    }
    void BuildBridge()
    {
        if (hasBeenBuilt)
        {
            return;
        }
        else
        {
            if (canBuild == true)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    
                    foreach (var gameObject in roots)
                    {

                        //Debug.Log("current z axis scale before change is " + zScale);
                        gameObject.transform.localScale = new Vector3(1, 1, bridgeLength);
                        //gameObject.isStatic = true;
                        
                        hasBeenBuilt = true;
                    }
                    foreach (var gameObject in barriers)
                    {
                        gameObject.GetComponent<BoxCollider>().enabled = true;
                    }
                }
                
            }
        }
    }
}
