using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FallPrevention : MonoBehaviour
{
    public ParticleSystem dazedParticles;
    public GameObject basicEnemyMesh;
    public BasicNavMeshEnemy enemyNavMeshAIBehaviourScript;
    [SerializeField]
    private NavMeshAgent enemyNavMeshAgent;
    [SerializeField]
    private Rigidbody enemyRigidbody;
    
    private void Start()
    {        
        enemyNavMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        enemyRigidbody = gameObject.GetComponentInParent<Rigidbody>();        
    }
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out RaycastHit hit))
        {
            if (hit.distance <= .25f)
            {
                enemyNavMeshAgent.enabled = true;
                enemyRigidbody.isKinematic = true;
                gameObject.GetComponent<FallPrevention>().enabled = false;
                                
                basicEnemyMesh.transform.localPosition = new Vector3(0,0,0);
                basicEnemyMesh.transform.rotation = new Quaternion(0,0,0,0);
                StartCoroutine("Dazed");
                dazedParticles.Play();
            }
        }
    }
    public void GetEnemyAIBehavior(ref BasicNavMeshEnemy other)
    {
        enemyNavMeshAIBehaviourScript = other;
    }
    public IEnumerator Dazed()
    {
        yield return new WaitForSeconds(2.5f);
        dazedParticles.Stop();
        enemyNavMeshAIBehaviourScript.enabled = true;
    }
    
}
