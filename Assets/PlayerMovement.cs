using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    private bool canMove = true;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        if (canMove == false)
        {
            horizontalMove = horizontalMove * -1;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
    }

    void stopMove()
    {
        canMove = false;
        rb.velocity = new Vector2(0, 0);
    }

    void letMove()
    {
        canMove = true;

    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        }
    }
}