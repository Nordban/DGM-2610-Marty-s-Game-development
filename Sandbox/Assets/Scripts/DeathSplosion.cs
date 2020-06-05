using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSplosion : MonoBehaviour
{

    public ParticleSystem deathSplosion;
    public GameObject parent;
    public GameObject enemyPrefab;

    private RootAttack rootAttack;
    private EnemyHealth enemyHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        rootAttack = GetComponent<RootAttack>();
        deathSplosion.Stop();
    }

    public void DeathSploision()
    {

        deathSplosion.Play();
        Debug.Log("DeathSplosion function run so partical system should play");
        Debug.Log("Starting Coroutine for deathSplosion");
        StartCoroutine(DeathSplosionTimer());
      
    }

    private IEnumerator DeathSplosionTimer()
    {
        
        yield return new WaitForSeconds(2f);
        

        Destroy(this.gameObject);
        Destroy(parent);
        Debug.Log("Destroying Enemy from deathSplosion script");
       
        
    }
}
