using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float dashSpeed = 5f;
    Rigidbody2D rb;
    Collider2D myCollider2D;
    bool canDoubleJump;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
	}
	
	void Update ()
    {
        Run();
        Jump();
        Dash();
        
    }

    bool IsFacingRight()
    {
        return rb.velocity.x > 0;
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    private void Jump()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) && canDoubleJump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpHeight);
                rb.velocity += jumpVelocityToAdd;
                canDoubleJump = false;
            }

        }
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpHeight);
                rb.velocity += jumpVelocityToAdd;
                canDoubleJump = true;
            }
        }
    }

    private void Dash()
    {
        //left ctrl
        if(Input.GetButtonDown("Dash"))
        {
            if (IsFacingRight())
            {
                Vector2 dashVelocityToAdd = new Vector2(dashSpeed, 0f);
                rb.velocity += dashVelocityToAdd;
            }

            else
            {
                Vector2 dashVelocityToAdd = new Vector2(-dashSpeed, 0f);
                rb.velocity += dashVelocityToAdd;
            }
        }
    }

}
