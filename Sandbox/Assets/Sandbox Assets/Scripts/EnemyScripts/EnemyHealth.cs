using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    
    public float health = 50;
    public float startHealth = 50;
    public bool isDead = false;

    public List<GameObject> vineEnemyList;
    public Image healthBar;
    public Canvas canvas;
    public GameObject[] children = new GameObject[4];
    //public RootAttack rootAttackScript;
    public Image healthBarPlaceHolder;
    public GameObject player;
    //[SerializeField]s
    //private GameObject areaClone;
    public AreaCleared areaCleared;
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
            vineEnemyList = player.transform.parent.GetComponentInChildren<KnockbackAttack>().enemies;
            if (vineEnemyList.Contains(this.gameObject))
            {
                vineEnemyList.Remove(this.gameObject);
            }
            isDead = true;
            areaCleared.EnemyDied(this.gameObject);
            //areaCleared.enemies.TrimExcess();
            //Debug.Log(areaCleared.enemies.Count);
            //Debug.Log("enemy should be removed");
            deathSplosion.DeathSploision();
            canvas.enabled = false;
           
            this.gameObject.GetComponent<MeshRenderer>().forceRenderingOff = true;
            //this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            foreach (var gameObject in children)
            {
                gameObject.SetActive(false);
            }
            gameObject.GetComponentInParent<BasicNavMeshEnemy>().enabled = false;
            gameObject.GetComponentInParent<NavMeshAgent>().enabled = false;
            //player.gameObject.GetComponentInChildren<RootAttack>().enemyList.Remove(this.gameObject);
        }
    }
}
