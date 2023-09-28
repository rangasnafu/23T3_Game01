using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    //ChatGPT
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;

    public CharacterController characterController;
    private bool isSprinting = false;
    //end ChatGPT

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private bool isGrounded;
    private Vector3 velocity;

    public GameObject gameOverUI;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = IsGrounded();

        
        //ChatGPT
        float moveSpeed = isSprinting ? sprintSpeed : walkSpeed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        //end ChatGPT

        velocity.y += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
        }
            
        

        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Sprint"))
        {
            isSprinting = true;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            isSprinting = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position - new Vector3(0, 1f, 0), Vector3.down, 0.6f, groundMask);
    }

   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - new Vector3(0, 1f, 0), transform.position - new Vector3(0, 1f, 0) + Vector3.down * 0.6f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if ()
        //{
        //      gameOverUI.SetActive(true);
        //}

        // compare tag with "Slime", when collide with player collider, set the Game Over UI as true
    }
}