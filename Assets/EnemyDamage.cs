using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] float DMG;
    private Player player;

    public Image healthBar;
	void Start ()
    {
        player = FindObjectOfType<Player>();

    }
	
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.health -= DMG;
            healthBar.fillAmount = player.health / 100f;
            
        }
    }
}
