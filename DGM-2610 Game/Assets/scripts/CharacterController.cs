
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{


    // Not Currently Using This Script.


    private bool canJump = false;
    private Rigidbody playerRigidbody;
    private Quaternion targetModelRotation;

    [Header("Visuals")]
    public GameObject model;
    public float rotationSpeed = 2f;

    [Header("Movment")]
    //comenting out moveSpeed as it is no longer being used
    //public float moveSpeed = 10f;
    public float jumpHeight = 10f;
    public float moveingVelocty;

    [Header("Equipment")]
    //public Sword sword;
    public GameObject bombPrefab;
    //public Bow bow;
    public int arrowAmount = 15;
    public int bombAmount = 5;
    public float throwingSpeed;


    // Use this for initialization
    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        ProcessInput();

    }
    void ProcessInput()
    {
        //Set velocity to 0 for x and z axis
        playerRigidbody.velocity = new Vector3(
            0,
            GetComponent<Rigidbody>().velocity.y,
            0);

        //Straife Right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Moving using the rigidbody
            //calling GetComponent is expensive on memory, changing to call previously created
            //rigidbody object
            //GetComponent<Rigidbody>().velocity = new Vector3(
            playerRigidbody.velocity = new Vector3(
                -moveingVelocty,
                GetComponent<Rigidbody>().velocity.y,
                GetComponent<Rigidbody>().velocity.z);
            //transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            // rotate character right using EulerAngles which go from 0, for our game 0 is looking at the camera, to 360.
            //90 faces the character to the left, 180 faces the character away from the camera
            //270 faces the character to the right
            //EulerAngles is not a smooth transition and can cause problems.
            //better for most situations to use Quaternions
            //model.transform.localEulerAngles = new Vector3(0, 270, 0);

            //Quaternions require 3 inputs, the first two are the points of rotation, starting and ending,
            //the third is the time you want it to take to go from starting to ending point
            //you can convert Euler angles to Quaternions using Quiternion.Eluer(value for x,value for y,value for z)
            model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime * rotationSpeed);

        }
        //Straife Left
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Moving using the rigidbody
            //calling GetComponent is expensive on memory, changing to call previously created
            //rigidbody object
            //GetComponent<Rigidbody>().velocity = new Vector3(
            playerRigidbody.velocity = new Vector3(
                moveingVelocty,
                GetComponent<Rigidbody>().velocity.y,
                GetComponent<Rigidbody>().velocity.z);
            //transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            //Quaternions require 3 inputs, the first two are the points of rotation, starting and ending,
            //the third is the time you want it to take to go from starting to ending point
            //you can convert Euler angles to Quaternions using Quiternion.Eluer(value for x,value for y,value for z)
            model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * rotationSpeed);
            //rotate character left
            //model.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        //Move Foward
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Moving using the rigidbody
            //calling GetComponent is expensive on memory, changing to call previously created
            //rigidbody object
            //GetComponent<Rigidbody>().velocity = new Vector3(
            playerRigidbody.velocity = new Vector3(
               GetComponent<Rigidbody>().velocity.x,
                GetComponent<Rigidbody>().velocity.y,
                -moveingVelocty);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);

            //Quaternions require 3 inputs, the first two are the points of rotation, starting and ending,
            //the third is the time you want it to take to go from starting to ending point
            //you can convert Euler angles to Quaternions using Quiternion.Eluer(value for x,value for y,value for z)
            model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotationSpeed);
            //look up
            //model.transform.localEulerAngles = new Vector3(0, 180, 0);
            /*
             * CODE TO LOCK ROTATION ANGLES WHEN BUTTON IS PRESSED
             * targetModelRotation = Quaternion.Euler(0,directions number,0);
             * delete  model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotationSpeed); 
             * from above then replace in each if statement
             */
        }

        //Move Backwards
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Moving using the rigidbody
            //calling GetComponent is expensive on memory, changing to call previously created
            //rigidbody object
            //GetComponent<Rigidbody>().velocity = new Vector3(
            playerRigidbody.velocity = new Vector3(
                GetComponent<Rigidbody>().velocity.x,
                GetComponent<Rigidbody>().velocity.y,
                +moveingVelocty);
            //Moving by transform
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);

            //Quaternions require 3 inputs, the first two are the points of rotation, starting and ending,
            //the third is the time you want it to take to go from starting to ending point
            //you can convert Euler angles to Quaternions using Quiternion.Eluer(value for x,value for y,value for z)
            model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
            //look down
            //model.transform.localEulerAngles = new Vector3(0, 0, 0);
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
            playerRigidbody.AddForce(0, jumpHeight, 0);
            playerRigidbody.velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, GetComponent<Rigidbody>().velocity.z);
            //not the right way to jump
            //transform.position += Vector3.up * jumpHeight * Time.deltaTime;


        }
        //CHECK EQUIPMENT INTERACTION
        if (Input.GetKeyDown(KeyCode.C))
        {
            //sword.gameObject.SetActive(true);
            //bow.gameObject.SetActive(false);

            //sword.Attack();

        }
        if (Input.GetKeyDown("z"))
        {
            ThrowBomb();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           // bow.gameObject.SetActive(true);
            //sword.gameObject.SetActive(false);
            if (arrowAmount > 0)
            {
                //bow.Attack();
                arrowAmount--;
            }

        }
    }

    private void ThrowBomb()
    {
        if (bombAmount <= 0)
        {
            return;
        }
        GameObject bombObject = Instantiate(bombPrefab);

        //transform.position + model.transform.foward ensures that the bomb is going to be 
        //instancated at the position of the player and facing the direction the player is.
        bombObject.transform.position = transform.position + model.transform.forward;

        // .normalized will ensure theat the vector3 has a value of 1.
        Vector3 throwingDirection = (model.transform.forward + Vector3.up).normalized;

        //get the bombObject rigidbody and then add force using the direction and multiplying it by the throwingSpeed
        bombObject.GetComponent<Rigidbody>().AddForce(throwingDirection * throwingSpeed);
        bombAmount--;

    }
}
