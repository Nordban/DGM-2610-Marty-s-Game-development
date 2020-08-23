using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //public GameObject enemyPrefab;

    public GameObject checkPointManager;
    public CharacterController character;
    public GameObject player;
    public List<GameObject> bodyParts;
    public BoxCollider feet;
    [SerializeField]
    private List<GameObject> enemySpawnPoints;

    private Vector3 spawnpoint;


    // Start is called before the first frame update
    private void Start()
    {
        character = player.gameObject.GetComponentInParent<CharacterController>();       
    }
    public void RespawnPlayer()
    {
        spawnpoint = checkPointManager.gameObject.GetComponent<CheckpointManager>().currentCheckpoint;
        character.transform.position = spawnpoint;
        
        player.GetComponent<PlayerHealth>().healthTxt.text = player.GetComponent<PlayerHealth>().health.ToString();
    }

    public void ReEnablePlayerControls()
    {
        //Debug.Log(character);
        character.enabled = true;
        character.GetComponent<SimpleMove>().enabled = true;
        
        character.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        this.gameObject.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        feet.enabled = true;
        player.GetComponent<Player_Normal_Attack>().enabled = true;
        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<PlayerHealth>().enabled = true;
        player.GetComponentInChildren<RootAttack>().enabled = true;
        player.GetComponent<MeshRenderer>().enabled = true;
        foreach (var gameObject in bodyParts)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
