using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private Player player;
    public float respawnDelay;
    private float gravityStore;

	void Start ()
    {
        player = FindObjectOfType<Player>();
	}
	
	void Update ()
    {
		
	}

    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }


}
