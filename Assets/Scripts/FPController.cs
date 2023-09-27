using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;

    public CharacterController characterController;
    private bool isSprinting = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private bool isGrounded;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float moveSpeed = isSprinting ? sprintSpeed : walkSpeed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        //if (isGrounded)
        //{
        //    velocity.y = -2f;

        //    if (Input.GetButtonDown("Jump"))
        //    {
        //        velocity.y = Mathf.Sqrt(jumpForce * -600f * Physics.gravity.y);
        //    }
        //}
        //else
        //{

        velocity.y += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
        }
            
        //}

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
}