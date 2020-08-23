using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardHealthBar : MonoBehaviour
{
    public Quaternion canvasTransform;


    // Update is called once per frame
    void Update()
    {
        //var x = this.transform.rotation.x;
        this.transform.rotation = canvasTransform;
    }
}
