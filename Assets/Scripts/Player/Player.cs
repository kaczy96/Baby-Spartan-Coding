﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Player : MonoBehaviour

{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] public float health = 100;
    [SerializeField] public float startingHealth = 100;
    [SerializeField] float cooldownBetweenDashes = 1;
    [SerializeField] float minimalTimeToNextDash;
    float timer;
    float direction;
    Rigidbody2D rb;
    Collider2D myCollider2D;
    bool canDoubleJump;
    private float timeToEndOfTheCurrentDash;
    [SerializeField] float minimalTimeSinceLastDash = 1;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGroud;
    private bool grounded;
    public bool facingRight;
    public Image healthBar;
    public GameObject currentCheckpoint;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    public bool isAttacking;
    public bool isJumping;
    public bool isFalling;
    private float attackTimer = 0f;
    private float attackCooldown = 0.5f;

    void Start()
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


    void Update()
    {
        if (!IsDashing())
        {
            Run();
            Jump();
        }

        HandleDash();


        Attack();

        myAnimator.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
        myAnimator.SetBool("ifGrounded", grounded);
        myAnimator.SetBool("ifDashing", IsDashing());
        myAnimator.SetBool("ifAttacking", isAttacking);
        myAnimator.SetBool("ifJumping", isJumping);
        myAnimator.SetBool("ifFalling", isFalling);




        if (Input.GetKeyDown("a"))
        {
            facingRight = false;
        }

        if (Input.GetKeyDown("d"))
        {
            facingRight = true;
        }



    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCooldown;
        }
        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
            }
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
        else if (CouldStartNextDash())
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }


    private void Jump()
    {

        if (rb.velocity.y <= 0)
        {
            grounded = true;
            isJumping = false;
            isFalling = false;
        }
        if (rb.velocity.y < -5) //temporary - need fix (values just for bridge)
        {
            grounded = false;
            isJumping = false;
            isFalling = true;
        }


        if (grounded)
        {
            canDoubleJump = true;
        }
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            grounded = false;
            isJumping = true;
            isFalling = false;
        }



        else if (canDoubleJump && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 1.2f);
            grounded = false;
            isJumping = true;
            isFalling = false;
            canDoubleJump = false;
        }

    }



    private void HandleDash()
    {
        minimalTimeToNextDash = DecreaseTime(minimalTimeToNextDash);
        timeToEndOfTheCurrentDash = DecreaseTime(timeToEndOfTheCurrentDash);

        if (minimalTimeToNextDash <= 0)
            if (Input.GetButtonDown("Dash"))
                StartDashing();
    }

    float DecreaseTime(float value)
    {
        return Mathf.Max(0, value - Time.deltaTime);
    }

    private void StartDashing()
    {
        timeToEndOfTheCurrentDash = 0.3f;
        minimalTimeToNextDash = cooldownBetweenDashes;

        if (facingRight)
        {
            rb.velocity = Vector2.right * dashSpeed;
        }

        if (!facingRight)
        {
            rb.velocity = Vector2.left * dashSpeed;
        }
    }

    bool CouldStartNextDash()
    {
        if (IsDashing())
            return false;
        if (minimalTimeToNextDash > 0)
            return false;
        return true;
    }

    bool IsDashing()
    {
        return timeToEndOfTheCurrentDash > 0;
    }



}