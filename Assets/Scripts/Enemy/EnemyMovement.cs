using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float enemySpeed;
    Rigidbody2D rb;


	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Vector2 enemyVelocity = new Vector2(enemySpeed, 0);
        rb.velocity = enemyVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemySpeed = enemySpeed * -1;
    }
}
