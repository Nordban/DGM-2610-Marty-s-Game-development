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
    public float runTimer;
    public float runAmount;
    public float runValue = 4f;
    public float speedValue = 1.75f;
    [SerializeField]
    private bool isTired = false;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lastMovedDir;
    private Vector3 lastPosition;
    [SerializeField]
    private bool moving = false;

    private Vector3 position = new Vector3(0, 0, 0);

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        //Dodge();
    }

    void Move()
    {
        speed = speedValue;
        MoveCheck();
        if (characterController.isGrounded)
        {

            if (Input.GetKey(KeyCode.LeftShift) && isTired == false && moving == true )
            {
                Run();                
            }
            if (Input.GetKey(KeyCode.LeftShift)!=true && isTired != true && runTimer > 0)
            {
                runTimer = runTimer -.25f * Time.deltaTime;
                
            }
            else if (runTimer < 0 )
            {
                runTimer = 0;
                
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
    void Run()
    {
        speed = runValue;

        
        runTimer = runTimer + 1f * Time.deltaTime;
        if (runTimer >= runAmount)//changed from (runTimer <=0)
        {
            isTired = true;
            StartCoroutine("RunCooldown");
        }
    }
    void MoveCheck()
    {
        if (position != gameObject.transform.position)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        position = gameObject.transform.position;
    }
    private IEnumerator RunCooldown()
    {

        yield return new WaitForSeconds(2);
        //runTimer = runAmount;
        isTired = false;
        runTimer = runTimer + 1f * Time.deltaTime;
        
    }
    //void Dodge()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {

    //        //Debug.Log("Last Moved Direction " + lastMovedDir );
    //        //Debug.Log("current transform position " + transform.position + " --------------");

    //        transform.localPosition = transform.position + lastMovedDir * dashDist;
    //        lastPosition = transform.localPosition;

    //        //Debug.Log("last position " + lastPosition);
    //        //Debug.Log("current transform position After Dash" + transform.position + " ------------");

    //        //Debug.Log("Last Moved Direction after dash " + lastMovedDir);
    //    }

    //}
}

