using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnpointManager : MonoBehaviour
{

    public List<GameObject> enemyAreas;
    public GameObject enemyAreaPrefab;
    int i = 0;
    

   
    // Start is called before the first frame update
    void Awake()
    {
        
        foreach (var item in enemyAreas)
        {
            GameObject area = Instantiate(enemyAreaPrefab, enemyAreas[i].gameObject.transform.localPosition, Quaternion.identity);
            area.GetComponent<AreaCleared>().parent = enemyAreas[i].gameObject;
            i++;
           
        }
                     

    }
    public void RemoveClearedArea(GameObject area)
    {
        enemyAreas.Remove(area.gameObject);
    }
    public void Respwan()
    {
        i = 0;

        var destroy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var item in destroy)
        {
            Destroy(item.gameObject);        
        }       
        //Remove Cleared areas here

        foreach (var item in enemyAreas)
        {
            GameObject area= Instantiate(enemyAreaPrefab, enemyAreas[i].gameObject.transform.position, Quaternion.identity);
            area.GetComponent<AreaCleared>().parent = enemyAreas[i].gameObject;
            i++;
        }
    }
}
