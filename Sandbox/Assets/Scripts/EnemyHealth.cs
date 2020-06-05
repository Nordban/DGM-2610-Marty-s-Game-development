using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float health = 50;
    public float startHealth = 50;
    public int normalDamage = 10;
    public int rootDamage = 30;
    public bool isDead = false;
    
    public Image healthBar;
    public Canvas canvas;
    [SerializeField]

    private GameObject player;
    [SerializeField]
    private RootAttack rootAttack;
    [SerializeField]
    private DeathSplosion deathSplosion;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        rootAttack = player.GetComponentInChildren<RootAttack>();
        deathSplosion = GetComponent<DeathSplosion>();
    }

    
    public void HealthCheck()
    {

        if (health >= 10)
        {
            return;
        }
        else if (health <= 10)
        {
            isDead = true;
            Debug.Log("Enemy dead");
            deathSplosion.DeathSploision();
            canvas.enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().forceRenderingOff = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
           
        }
      
    }
   
    
}
