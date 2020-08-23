using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Normal_Attack : MonoBehaviour
{
    public Swing swing;
    GameObject pivot;
    
    // Start is called before the first frame update
    void Start()
    {
        pivot = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Swinging();
    }

    void Swinging()
    {
        if (Input.GetKey(KeyCode.C))
        {
            
            swing.Attack();
        }
    }
}
