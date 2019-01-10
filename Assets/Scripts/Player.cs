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
    private bool isDashing;
    private float dashTime;
    [SerializeField] float startDashTime;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGroud;
    private bool grounded;
    public bool facingRight;
    public Image healthBar;
    public GameObject currentCheckpoint;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    void Start ()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
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

        myAnimator.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
        myAnimator.SetBool("ifGrounded", grounded);
        myAnimator.SetBool("ifDashing", isDashing);
    

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
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector3(runSpeed, rb.velocity.y, 0f);
            mySpriteRenderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector3(-runSpeed, rb.velocity.y, 0f);
            mySpriteRenderer.flipX = true;
        }
        else rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
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

        if (Input.GetButtonDown("Dash"))
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
                isDashing = true;
            }
        }
        else isDashing = false;
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
