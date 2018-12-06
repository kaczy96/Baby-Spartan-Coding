using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float dashSpeed = 5f;
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Run();
        Jump();
        Dash();
	}

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpHeight);
            rb.velocity += jumpVelocityToAdd;
        }

    }

    private void Dash()
    {
        if(Input.GetButtonDown("Dash"))
        {
            Vector2 dashVelocityToAdd = new Vector2(dashSpeed, 0f);
            rb.velocity += dashVelocityToAdd;
        }
    }

}
