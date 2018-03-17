using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {
    public float maxSpeed = 10.0f;
    public Transform GroundCheck;
    public LayerMask DefineGround;
    public float JumpForce = 200;


    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator anim;
    private float groundCheckRadius = 0.2f;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Jump")>0 && isGrounded) {
            anim.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, JumpForce));
         }

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, DefineGround);

        Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, DefineGround);

        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rBody.velocity.y);

        float moveHorizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        rBody.velocity = new Vector2(moveHorizontal * maxSpeed, rBody.velocity.y);

        if (moveHorizontal > 0)
        {
            sRend.flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            sRend.flipX = true;
        }
    }
}
