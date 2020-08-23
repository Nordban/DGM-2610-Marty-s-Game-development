using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnpointLogic : MonoBehaviour
{
    public GameObject enemyPrefab;
    public AreaCleared areaClearedScript;
    private EnemyHealth healthScript;
    private void Awake()
    {
        GameObject enemy = Instantiate(enemyPrefab,this.gameObject.transform.position,Quaternion.identity);
        areaClearedScript.enemies.Add(enemy);

        healthScript = enemy.GetComponentInChildren<EnemyHealth>();
        healthScript.areaCleared = this.gameObject.GetComponentInParent<AreaCleared>();
    }
}
