using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public TextMeshProUGUI healthTxt;
    public int health;
    
    public BoxCollider feet;
    public DeathUI death;
   
    public CharacterController character;
    public List<GameObject> bodyParts;
    private readonly int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthTxt.text = health.ToString();
       
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "EnemyArm")
    //    {
    //        Debug.Log("Something hit me");
    //        DamageDelt();
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyArm")
        {
            //Debug.Log("Something hit me");
            DamageDelt();
        }
        if (other.gameObject.tag == "Abyss")
        {
            healthTxt.text = 0.ToString();
            Death(1);
        }
    }

    void DamageDelt()
    {

        if (health <= 10)
        {
            healthTxt.text = 0.ToString();
            Death();
        }
        else if (health > 0)
        {
            health -= damage;

            healthTxt.text = health.ToString();
        }
    }

    void Death()
    {        
        death.EnableDeathUI();
        character.enabled = false;
        gameObject.GetComponentInChildren<RootAttack>().enabled = false;
        character.GetComponent<SimpleMove>().enabled = false;
        feet.enabled = false;
        gameObject.GetComponent<Player_Normal_Attack>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        character.gameObject.transform.position = new Vector3(this.transform.position.x, -.5f, this.transform.position.z);
        this.gameObject.transform.Rotate(Vector3.right, -90f);
        this.gameObject.GetComponent<PlayerHealth>().enabled = false;
    }
    void Death(int one)
    {
        death.EnableDeathUI();
        character.enabled = false;
        gameObject.GetComponentInChildren<RootAttack>().enabled = false;
        character.GetComponent<SimpleMove>().enabled = false;
        feet.enabled = false;
        gameObject.GetComponent<Player_Normal_Attack>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        character.gameObject.transform.position = new Vector3(this.transform.position.x, -.5f, this.transform.position.z);
        this.gameObject.transform.Rotate(Vector3.right, -90f);
        this.gameObject.GetComponent<PlayerHealth>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        foreach (var gameObject in bodyParts)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
