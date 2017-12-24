using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myRB;
    SpriteRenderer mySR;

    public float maxSpeed;

    bool facingRight = true;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        Debug.Log(move);

        if(move > 0 && !facingRight)
        {
            flip();
        }
        else if(move < 0 && facingRight)
        {
            flip();
        }

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
	}

    void flip()
    {
        facingRight = !facingRight;
        mySR.flipX = !mySR.flipX;
    }
}
