using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public TextMeshProUGUI healthTxt;
    public int health = 100;
    public GameObject player;
    public GameObject deadPlayer;
    public TextMeshProUGUI deathTxt;
    public CharacterController character;
    private readonly int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthTxt.text = health.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit something");
            DamageDelt();
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        Debug.Log("I triggered something");
    //        DamageDelt();
    //    }

    //}

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
        Debug.Log("opps i died");
        deathTxt.gameObject.SetActive(true);
        //character = gameObject.GetComponentInParent<CharacterController>();
        character.enabled = false;
        character.GetComponent<SimpleMove>().enabled = false;
        character.transform.position = new Vector3(this.transform.position.x, -.5f, this.transform.position.z);
        this.gameObject.transform.Rotate(Vector3.right,-45f);
        player.GetComponent<Rigidbody>().Sleep();

        //GameObject dead = Instantiate(deadPlayer);
        //player.transform.rotation = player.transform.rotation * Quaternion.AngleAxis(-90,Vector3.forward);
        ////player.gameObject.GetComponent<CharacterController>().enabled = false;
        //// make the player object rotate backwords for the death pose
        //dead.transform.position = player.transform.position;
        //dead.transform.rotation = Quaternion.Euler(180, player.transform.rotation.y, 0);
        //player.SetActive(false);
        
    }
}
