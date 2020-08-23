using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRock : MonoBehaviour
{
    public GameObject rock;
    
    [SerializeField]
    bool canDestroy = false;
   
    [SerializeField]
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = rock.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyRock();       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canDestroy = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canDestroy = false;
    }
    void DestroyRock()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canDestroy)
        {
            particles.Play();
            rock.GetComponent<MeshRenderer>().enabled = false;
            rock.GetComponent<Collider>().enabled = false;
            canDestroy = false;
            
            this.gameObject.GetComponent<Collider>().enabled = false;
           
            StartCoroutine("Remove");
        }
        
        
    }
    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(2);
        Destroy(rock.gameObject);
        gameObject.GetComponent<RemoveRock>().enabled = false;
    }
   
}
