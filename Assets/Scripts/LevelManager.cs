using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    private float gravityStore;

	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
	}
	
	void Update ()
    {
		
	}

    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }


}
