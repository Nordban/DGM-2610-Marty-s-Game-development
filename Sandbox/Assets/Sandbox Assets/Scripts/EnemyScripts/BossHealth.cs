using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class BossHealth : MonoBehaviour
{
    
    public float health = 50;
    public float startHealth = 50;
    public bool isDead = false;

    public Image healthBar;
    public Canvas canvas;
    public GameObject[] children = new GameObject[4];
    //public RootAttack rootAttackScript;
    public Image healthBarPlaceHolder;
    [SerializeField]
    private GameObject player;
    //[SerializeField]s
    //private GameObject areaClone;
    
    [SerializeField]
    private DeathSplosion deathSplosion;

    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindWithTag("Player");
        //Debug.Log(player + " Player found");
        
        deathSplosion = GetComponent<DeathSplosion>();
    }

    public void HealthCheck()
    {
        //healthBar.fillAmount = health / 100f;
        //Debug.Log(healthBar.fillAmount);
        if (health >= 10)
        {
            return;
        }
        else if (health <= 10)
        {
            isDead = true;
            
            deathSplosion.DeathSploision();
            canvas.enabled = false;
           
            this.gameObject.GetComponent<MeshRenderer>().forceRenderingOff = true;
            //this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            foreach (var gameObject in children)
            {
                gameObject.SetActive(false);
            }
            gameObject.GetComponentInParent<BossMovment>().enabled = false;
            gameObject.GetComponentInParent<NavMeshAgent>().enabled = false;
            //player.gameObject.GetComponentInChildren<RootAttack>().enemyList.Remove(this.gameObject);
        }
    }
}
