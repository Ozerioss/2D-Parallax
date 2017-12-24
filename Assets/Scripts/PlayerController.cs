using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myRB;
    SpriteRenderer mySR;
    Animator myAnim;

    // movement
    public float maxSpeed;
    bool facingRight = true;

    //Jumping 

    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
        flip(); // workaround
	}
	
	// Update is called once per frame
	void Update () {

        //player jumping
        if (grounded && Input.GetAxis("Jump") > 0) 
        {
            myAnim.SetBool("isGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);   //creates a circle at feet and checks if there is an overlap
        myAnim.SetBool("isGrounded", grounded); // Sets bool in animator


        // Horizontal movement
        float move = Input.GetAxis("Horizontal");

        if(move > 0 && !facingRight)
        {
            flip();
        }
        else if(move < 0 && facingRight)
        {
            flip();
        }

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        myAnim.SetFloat("MoveSpeed", Mathf.Abs(move)); // Sets float in animator
	}

    // Flips characters X axis
    void flip()
    {
        facingRight = !facingRight;
        mySR.flipX = !mySR.flipX;
    }
}
