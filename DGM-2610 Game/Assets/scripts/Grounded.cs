using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private Vector3 pos;
    
   
    // Update is called once per frame
    void Update()
    {

        pos.y = transform.position.y;
        float terrainHeight = Terrain.activeTerrain.SampleHeight(pos);
        transform.position = new Vector3(pos.x,
                                         terrainHeight,
                                         pos.z);
    }
}
