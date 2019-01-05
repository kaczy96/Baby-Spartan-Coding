using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float dashSpeed = 5f;
    public float health = 100;
    public float startingHealth = 100;
    public float coolDown = 1;
    public float coolDownTimer;
    float timer;
    float direction;
    Rigidbody2D rb;
    Collider2D myCollider2D;
    bool canDoubleJump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGroud;
    private bool grounded;

    private bool facingRight;

    void Start ()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGroud);
    }


    void Update ()
    {
        Run();
        Jump();
        
        if(coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if(coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if(coolDownTimer == 0)
        {
            Dash();
        }

        Debug.Log(IsFacingRight());
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
        if (!grounded && canDoubleJump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                canDoubleJump = false;
            }

        }
        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
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
                    coolDownTimer = coolDown;
                }

                if(!IsFacingRight())
                {
                    Vector2 dashVelocityToAdd = new Vector2(-dashSpeed, 0f);
                    rb.velocity += dashVelocityToAdd;
                    coolDownTimer = coolDown;
                }
        }
    }

}
