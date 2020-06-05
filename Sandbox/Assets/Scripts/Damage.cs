using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    //public int health = 50;
    public int normalDamage = 10;
    public int rootDamage = 30;

    //public GameObject parent;
    //public GameObject enemyPrefab;


    
    private EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerArm")
        {
            NormalDamageRecived();
        }
        else if (other.tag == "RootAttack")
        {
            RootDamageRecived();
        }

    }

    void NormalDamageRecived()
    {
        Debug.Log("Trigger Hit");
        this.enemyHealth.health -= normalDamage;
        enemyHealth.healthBar.fillAmount = enemyHealth.health / enemyHealth.startHealth;
        enemyHealth.HealthCheck();
    }

    void RootDamageRecived()
    {
        Debug.Log("Trigger Hit Root Attack");
        this.enemyHealth.health -= rootDamage;
        enemyHealth.healthBar.fillAmount = enemyHealth.health / enemyHealth.startHealth;
        enemyHealth.HealthCheck();
    }




}
