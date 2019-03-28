using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour {

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
	
	void Update ()
    {
        Death();
    }

    public  void Death()
    {
        if (player.health <= 0)
        {
            Debug.Log("Player just die");
            healthBar.fillAmount = player.startingHealth;
            player.health = player.startingHealth;
            player.transform.position = currentCheckpoint.transform.position;
            
        }

    }

}
