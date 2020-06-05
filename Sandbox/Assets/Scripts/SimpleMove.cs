using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{




    public CharacterController characterController;

    
    public float speed;
    public float jumpSpeed = 4.0f;
    public float gravity = 20.0f;

    public float dashDist = 5f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lastMovedDir;
    private Vector3 lastPosition;





    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //character = GetComponent<GameObject>();
    }
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        Move();
        Dodge();
    }

    void Move()
    {
        speed = 6f;

        if (characterController.isGrounded)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 20f;
            }

            moveDirection.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
                //characterController.Move(moveDirection / 8);

                lastMovedDir = moveDirection;
            }
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;

            }
        }
        //lastMovedDir = moveDirection;
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * speed * Time.deltaTime);

    }
    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            //Debug.Log("Last Moved Direction " + lastMovedDir );
            Debug.Log("current transform position " + transform.position + " --------------");
           
            transform.localPosition = transform.position + lastMovedDir * dashDist;
            lastPosition = transform.localPosition;

            Debug.Log("last position " + lastPosition);
            Debug.Log("current transform position After Dash" + transform.position + " ------------");

            //Debug.Log("Last Moved Direction after dash " + lastMovedDir);
        }
       
    }
}

