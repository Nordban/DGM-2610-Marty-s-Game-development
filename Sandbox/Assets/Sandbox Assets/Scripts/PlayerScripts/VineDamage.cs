using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VineDamage : MonoBehaviour
{
    public BasicNavMeshEnemy navMeshEnemyBehaviourScript;
    [SerializeField]
    private NavMeshAgent enemyNavMeshAgent;
    [SerializeField]
    private Rigidbody enemyRigidbody;
    [SerializeField]
    private Vector3 hitPosition;
    [SerializeField]
    private bool canAddForce = false;
    
    [SerializeField]
    private FallPrevention fallPreventionScript;
    [SerializeField]
    private GameObject enemy;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyNavMeshAgent")
        {
            enemy = other.gameObject;
            enemyNavMeshAgent = other.GetComponent<NavMeshAgent>();
            enemyRigidbody = other.GetComponent<Rigidbody>();
            navMeshEnemyBehaviourScript = other.GetComponent<BasicNavMeshEnemy>();
            fallPreventionScript = other.GetComponentInChildren<FallPrevention>();
            canAddForce = true;
            Debug.Log("can add force");
        }
        
        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit))
        {
            hitPosition = hit.point;
        }        

        if (canAddForce)
        {
            ApplyForce();
        }
    }
    void ApplyForce()
    {
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        enemyNavMeshAgent.enabled = false;
        enemyRigidbody.isKinematic = false;
        enemyRigidbody.AddExplosionForce(5, hitPosition, 1, 1, ForceMode.Impulse);
        Debug.Log("Explosion force Applied");
        
        navMeshEnemyBehaviourScript.enabled = false;
        fallPreventionScript.GetEnemyAIBehavior(ref navMeshEnemyBehaviourScript);
        StartCoroutine("ResetNavMesh");
        
    }
    private IEnumerator ResetNavMesh()
    {
        yield return new WaitForSeconds(.3f);
        fallPreventionScript.enabled = true;       
        
        

    }
    //private IEnumerator Dazed()
    //{
    //    Debug.Log("Dazed should be running");
    //    yield return new WaitForSeconds(2.5f);
    //    navMeshEnemyBehaviourScript.enabled = true;
    //}
}
