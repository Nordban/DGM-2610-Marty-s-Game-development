
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacterController1 : MonoBehaviour
{

    public float speed = 20f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    public bool canJump = false;
    public Transform groundChecker;
   
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
   

    void Start()
    {
        _body = GetComponent<Rigidbody>();
      
    }

    void Update()
    {

        var _isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Vertical");
        _inputs.z = Input.GetAxis("Horizontal");
        _inputs.z = - _inputs.z;
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            
        }
        //Return information from a ray cast, returns a bool
        //Create a local RaycastHit variable
        RaycastHit hit;
        //use Phisics.Raycast to get information from the raycast. requires 4 inputs,
        //(position where raycast is originating, direction raycast is going, where the information is saved,
        //using the out keyword to access the local hit variable from above, the distance the raycast goes out)
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
        {
            //ste can jump eaqual to true
            canJump = true;
        }



        //Check to see if you can Jump
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
           _body.AddForce(0, jumpHeight, 0);
           _body.velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, GetComponent<Rigidbody>().velocity.z);
            


        }
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * speed * Time.fixedDeltaTime);
    }


}
