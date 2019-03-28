using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armour;
    public LevelManager levelManager;
    private Player player;
    public Image healthBar;
    public GameObject currentCheckpoint;
    Rigidbody2D rb;

    [SerializeField] Transform spawnPoint;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
//        if (Input.GetKeyDown(KeyCode.K))
//        {
//            TakeDamage(10);
//            Debug.Log("Current health: "+ currentHealth);
//        }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
         player.transform.position = currentCheckpoint.transform.position;
         Debug.Log("player just died");
         Awake();
    }
}
