using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{


    public float speed = 20.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;


    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 playerTransformPosition;
        
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        PlayerTransform();
        characterController = player. GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public Vector3 PlayerTransform()
    {
        playerTransformPosition = player.transform.position;
        return playerTransformPosition;
    }

    void Move()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
