using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;

    public Transform groundCheck;
    public float checkRadius;

    float MoveSpeed;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpForce;
    public float fallSpeed;
    float gravity = -9.81f;

    bool isRunning;
    public bool isGrounded;

    public LayerMask whatIsGround;

    Vector3 moveVelocity;
    Vector3 fallVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);
        ControlAll();
    }

    void ControlAll()
    {
        Movement();
    }

    void Movement()
    {
        if(isGrounded && fallVelocity.y < 0)
        {
            fallVelocity.y = -fallSpeed;
        }

        if (isRunning)
        {
            MoveSpeed = runningSpeed;
        }
        else
        {
            MoveSpeed = walkingSpeed;
        }

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        moveVelocity = transform.right * xInput + transform.forward * zInput;
        controller.Move(moveVelocity * MoveSpeed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            fallVelocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            print("jump!");
        }

        fallVelocity.y += gravity * Time.deltaTime;
        controller.Move(fallVelocity * Time.deltaTime);
    }


}
