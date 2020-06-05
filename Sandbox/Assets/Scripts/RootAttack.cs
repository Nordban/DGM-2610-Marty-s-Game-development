using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootAttack : MonoBehaviour
{


    public GameObject player;
    public bool canAttack = false;
    public GameObject rootPrefab;
    public int damage;
    public List<GameObject> enemyList;
    public List<GameObject> rootList;
    public float coolDown = 2f;
    public IconCooldown icon;

    //private Collider attackArea;
    private EnemyHealth enemyHealth;
    private float timer = 0.5f;
    private GameObject root;
    private bool isAttacking = false;



    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyList = new List<GameObject>();
        rootList = new List<GameObject>();

    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            canAttack = true;

            enemyList.Add(other.gameObject);
        }

    }
  
    private void OnTriggerExit(Collider other)
    {
        if (enemyList.Contains(other.gameObject))
        {
            
            enemyList.Remove(other.gameObject);

        }
        if (enemyList.Count <1 )
        {
            canAttack = false;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X)/* && enemyList.Count > 1 && isAttacking != true*/)
        {
            if (canAttack == false)
            {
                return;
            }
            canAttack = true;

            foreach (var enemy in enemyList)
            {
                if (enemy != null)
                {
                    root = Instantiate(rootPrefab, enemy.transform.position, Quaternion.identity);
                    rootList.Add(root);
                }
            }
            icon.currentCooldown = 0f;

            StartCoroutine(AttackDuration());

            icon.cooldownTimer = 2.5f;
        }
       

    }

    private IEnumerator AttackDuration()
    {
        canAttack = false;
        isAttacking = true;
        yield return new WaitForSeconds(timer);
        //TODO
        // PASS DAMAGE TO ENEMY
        foreach (var root in rootList)
        {
            Destroy(root);
        }
        rootList.Clear();

        StartCoroutine(Cooldown());

    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolDown);
        isAttacking = false;
        if (enemyList.Count >= 1)
        {
            Debug.Log("I have more enemy's in my list");

            canAttack = true;
            Debug.Log(canAttack);
        }
        else
        {
            canAttack = false;
        }
       
    }

}
