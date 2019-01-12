using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    private Player player;

    public Image healthBar;
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            healthBar.fillAmount = 0;
            player.health = 0;

        }
    }
}


