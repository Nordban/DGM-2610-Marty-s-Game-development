using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Normal_Attack : MonoBehaviour
{
    public Swing swing;
    GameObject pivot;
    //GameObject hitBox;
    //float swingTime;
    //float damage;

    // Start is called before the first frame update
    void Start()
    {
        pivot = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        Swinging();
    }

    void Swinging()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            swing.Attack();
        }
    }
}
