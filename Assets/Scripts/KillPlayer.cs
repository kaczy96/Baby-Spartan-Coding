using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    private Player player;
    public Image healthBar;

    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
	}
	
	void Update ()
    {
        Death();
	}

    private void Death()
    {
        if(player.health <= 0)
        {
            Debug.Log("Player just die");
            levelManager.RespawnPlayer();
            healthBar.fillAmount = player.startingHealth;
        }
    }

}
