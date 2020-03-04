using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject character;
    public Camera followCamera;
    public Vector3 positionOffset = new Vector3(-3.5f, 2.61f, -1.5f);
    public GameObject cameraTarget;
    //public Vector3 rotationOffset = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {

        followCamera.transform.position = character.transform.position - positionOffset;
        followCamera.transform.LookAt(character.transform);
        followCamera.orthographicSize = 5.5f;
        followCamera.nearClipPlane = -35f;
       
    }

    // Update is called once per frame
    void Update()
    {

        followCamera.transform.position = character.transform.position - positionOffset;
        
    }
}
