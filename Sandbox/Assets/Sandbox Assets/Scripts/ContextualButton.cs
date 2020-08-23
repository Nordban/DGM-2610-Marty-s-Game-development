using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextualButton : MonoBehaviour
{
    public GameObject contextualButtonInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Continue();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            contextualButtonInfo.SetActive(true);
            bool pause = true;
            if (pause)
            {
                Time.timeScale = 0;
            }
            
        }
        
    }
    void Continue()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            contextualButtonInfo.SetActive(false);
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
