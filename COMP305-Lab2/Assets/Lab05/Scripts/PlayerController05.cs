﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController05 : MonoBehaviour
{

    public float maxSpeed = 10;
    public float jumpForce = 700f;
    public float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask defineGround;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private float moveH;
    private bool isRight = true;
    private bool isGrounded = false;

    // Counts how many objects of each kind were collected
    public int[] objectCollected = { 0, 0, 0 };

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0 && rBody.velocity.y == 0.0f)
        {
            animator.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Do not need to use Time.deltaTime()
    void FixedUpdate()
    {
        // Checks whether character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, defineGround);
        animator.SetBool("Ground", isGrounded);

        // Debug.Log("Grounded? " + isGrounded);

        // Pass vertical velocity to animator
        animator.SetFloat("vSpeed", rBody.velocity.y);

        if (isGrounded)
        {
            // Read input
            moveH = Input.GetAxis("Horizontal");

            // Set speed variable in animator
            animator.SetFloat("Speed", Mathf.Abs(moveH));

            // Set character velocity
            rBody.velocity = new Vector2(moveH * maxSpeed, rBody.velocity.y);

            // Check direction and flip sprite
            if (moveH > 0)
            {
                sRend.flipX = false;
            }
            else if (moveH < 0)
            {
                sRend.flipX = true;
            }
        }
    }

    public void CollectObject(int i)
    {
        objectCollected[i] += 1;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
