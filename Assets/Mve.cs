using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mve : MonoBehaviour
{
    CharacterController controller;

    public Transform groundCheck;

    public LayerMask groundMask;

    Vector3 move;
    Vector3 input;

    float speed;
    public float runSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float airSpeed;

    Vector3 velocityY;

    int jumpCharges;


    bool isGrounded;
    bool isSprinting;
    bool isCrouching;

    float gravity;
    public float normalGravity;

    public float jumpHeight;

    float startHeight;
    float crouchHeight;
    Vector3 crouchingCenter = new Vector3 (0, 0.5f, 0);
    Vector3 standingCenter = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startHeight = transform.localScale.y;
    }

    void HandleInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        input = transform.TransformDirection(input); //Lets player move in corilation to camera
        input = Vector3.ClampMagnitude(input, 1f);

        if(Input.GetKeyUp(KeyCode.Space) && jumpCharges > 0)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            ExitCrouch();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            isSprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (isGrounded)
        {
            GroundedMovement();
        }
        else
        {
            AirMovement();
        }
        checkGround();
        controller.Move(move * Time.deltaTime);
        applyGravity();
    }

    void GroundedMovement()
    {
        speed = isSprinting ? sprintSpeed : isCrouching ? crouchSpeed: runSpeed; //Controlls movement and stops player when let go
        if (input.x != 0)
        {
            move.x += input.x * speed;
        }
        else
        {
            move.x = 0;
        }

        if (input.z != 0)
        {
            move.z += input.x * speed;
        }
        else
        {
            move.z = 0;
        }

        move = Vector3.ClampMagnitude(move, speed);
    }

    void checkGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        if (isGrounded)
        {
            jumpCharges = 1;
        }
    }

    void applyGravity()
    {
        gravity = normalGravity;
        velocityY.y += gravity * Time.deltaTime;
        controller.Move(velocityY * Time.deltaTime);
    }

    void Jump()
    {
        velocityY.y = Mathf.Sqrt( jumpHeight * -2f * normalGravity);
    }

    void Crouch()
    {
        controller.height = crouchHeight;
        controller.center = crouchingCenter;
        transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
        isCrouching = true;
    }

    void ExitCrouch()
    {
        controller.height = startHeight * 2;
        controller.center = standingCenter;
        transform.localScale = new Vector3(transform.localScale.x, startHeight, transform.localScale.z);
        isCrouching = false;
    }

    void AirMovement()
    {
        move.x += input.x * airSpeed;
        move.z += input.x * airSpeed;
    }
}
