using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{   
    public int normalDamage = 10;
    public int rootDamage = 30;
           
    private EnemyHealth enemyHealth;
    private BossHealth bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        bossHealth = GetComponent<BossHealth>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerArm")
        {
            //Debug.Log(this.gameObject.name + " This is what i hit");
            //Debug.Log(normalDamage + " Root Damage recived");
            if (this.gameObject.tag == "Enemy")
            {
                NormalDamageRecived();
            }
            else if (this.gameObject.tag == "Boss")
            {
                NormalBossDamageRecived();
            }
            
        }
        else if (other.tag == "RootAttack")
        {
            //Debug.Log(this.gameObject.name + " This is what i hit");
            //Debug.Log(rootDamage + " Root Damage recived");
           
            if (this.gameObject.tag == "Enemy")
            {
                RootDamageRecived();
            }
            else if (this.gameObject.tag == "Boss")
            {
                RootBossDamageRecived();
            }
        }
    }

    void NormalDamageRecived()
    {
        //Debug.Log("Trigger Hit");
        this.enemyHealth.health -= normalDamage;
        enemyHealth.healthBar.fillAmount = enemyHealth.health / enemyHealth.startHealth;
        //Debug.Log(this.enemyHealth.health);
        enemyHealth.HealthCheck();
    }

    void RootDamageRecived()
    {
       // Debug.Log("Trigger Hit Root Attack");
        this.enemyHealth.health -= rootDamage;
        enemyHealth.healthBar.fillAmount = enemyHealth.health / enemyHealth.startHealth;
        enemyHealth.HealthCheck();
    }
    void NormalBossDamageRecived()
    {
        this.bossHealth.health -= normalDamage;
        bossHealth.healthBar.fillAmount = bossHealth.health / bossHealth.startHealth;
        bossHealth.HealthCheck();
    }
    void RootBossDamageRecived()
    {
        this.bossHealth.health -= rootDamage;
        bossHealth.healthBar.fillAmount = bossHealth.health / bossHealth.startHealth;
        bossHealth.HealthCheck();
    }



}
