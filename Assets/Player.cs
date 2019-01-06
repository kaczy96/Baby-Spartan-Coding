using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] public float health = 100;
    [SerializeField] public float startingHealth = 100;
    [SerializeField] float coolDown = 1;
    [SerializeField] float coolDownTimer;
    float timer;
    float direction;
    Rigidbody2D rb;
    Collider2D myCollider2D;
    bool canDoubleJump;
    private float dashTime;
    [SerializeField] float startDashTime;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGroud;
    private bool grounded;
    public bool facingRight;
    public Image healthBar;
    public GameObject currentCheckpoint;

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
        DashCooldown();
    

        Debug.Log(facingRight);


        if (Input.GetKeyDown("a"))
        {
            facingRight = false;
        }

        if (Input.GetKeyDown("d"))
        {
            facingRight = true;
        }
    }


    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    private void Jump()
    {
        
            if(rb.velocity.y == 0)
            {
            grounded = true;
            }
            else
            {
            grounded = false;
            }

            if(grounded)
            {
            canDoubleJump = true;
            }
            if (grounded && Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            }

        
        
            else if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            canDoubleJump = false;
            }
        

        
        
    }

    private void Dash()
    {
        //left ctrl
        
        if(Input.GetButtonDown("Dash"))
        {
            if (dashTime <= 0)
            {
                dashTime = startDashTime;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (facingRight)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    coolDownTimer = coolDown;
                }

                if (!facingRight)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    coolDownTimer = coolDown;
                }
            }
        }
    }

    private void DashCooldown()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (coolDownTimer == 0)
        {
            Dash();
        }
    }

    

   
}
