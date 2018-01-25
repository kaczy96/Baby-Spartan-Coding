using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolUpDown : MonoBehaviour
{

    public float moveSpeed;
    public bool moveUp;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool wall;

    void Start()
    {

    }

    void Update()
    {
        wall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (wall)
        {
            moveUp = !moveUp;
        }

        if (moveUp)
        {
            transform.localScale = new Vector3(1f, 1f, -1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
