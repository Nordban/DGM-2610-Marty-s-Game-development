using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootAttack : MonoBehaviour
{


    public GameObject player;
    public bool canAttack = false;
    public GameObject rootPrefab;
    
    public List<GameObject> enemyList;
    public List<GameObject> rootList;
    public float coolDown = 2f;
    public IconCooldown icon;

   
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
  
    private void FixedUpdate()
    {
        Attack();
    }
    private void OnDisable()
    {
        enemyList.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag=="Boss")
        {
            enemyList.Add(other.gameObject);
        }
        if (isAttacking == false && other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            canAttack = true;
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
        
        if (Input.GetKeyDown(KeyCode.X) && isAttacking != true)
        {
            if (canAttack == false || isAttacking == true)
            {
                return;
            }
            canAttack = true;
            isAttacking = false;
            foreach (var enemy in enemyList)
            {
                if (enemy != null)
                {
                    root = Instantiate(rootPrefab, enemy.transform.position, Quaternion.identity);
                    rootList.Add(root);
                }
            }
            isAttacking = true;
            canAttack = false;

            icon.currentCooldown = 0f;

            StartCoroutine(AttackDuration());

            icon.cooldownTimer = 5f;
        }
       

    }

    private IEnumerator AttackDuration()
    {
        
        yield return new WaitForSeconds(timer);
        
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
        
        //Debug.Log(enemyList.Count + " My current enemy count");
        for (int i = enemyList.Count -1; i > -1 ; i--)
        {
            if (enemyList.Count == 0)
            {
                break;
            }
            //Debug.Log(i + " This is how many enemies i have removed");
            if (enemyList[i].gameObject == null)
            {
                enemyList.Remove(enemyList[i].gameObject);
            }
        }

        if (enemyList.Count >= 1)
        {
            //Debug.Log("I have more enemy's in my list");

            canAttack = true;
            
            //Debug.Log(canAttack);
        }
        else
        {
            canAttack = false;

        }
       
    }

}
