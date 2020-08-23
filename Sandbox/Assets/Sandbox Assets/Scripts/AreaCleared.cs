using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCleared : MonoBehaviour
{
    //public GameObject area;
    //public int enemyCount;
    public bool isAreaCleared = false;
    public List<GameObject> enemies;
    //public EnemySpawnpointManager enemySpawnpointManagerScript;
    public GameObject parent;
    [SerializeField]
    private EnemySpawnpointManager enemySpawnpointManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnpointManagerScript = parent.GetComponentInParent<EnemySpawnpointManager>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnemyDied(GameObject enemy)
    {
        enemies.Remove(enemy.gameObject);
        Debug.Log("Enemy should be removed now");
        StartCoroutine(ClearTimer());
    }
    void UpdateList()
    {
        //foreach (GameObject enemy in enemies)
        //{
        //    if (enemy == null)
        //    {
        //        enemies.Remove(enemy);
        //    }
        //}
        for (int i = 0; i <enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i].gameObject);
            }
        }
        if (enemies.Count == 0)
        {
            //isAreaCleared = true;
            enemySpawnpointManagerScript.RemoveClearedArea(parent.gameObject);
        }
    }
    IEnumerator ClearTimer()
    {
        yield return new WaitForSeconds(3);
        UpdateList();
    }
}



