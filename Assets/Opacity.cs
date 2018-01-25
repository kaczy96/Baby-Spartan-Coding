using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opacity : MonoBehaviour {

    public SpriteRenderer spawnPoint;

	void Start ()
    {

        

    }
	
	// Update is called once per frame
	void Update () {
        spawnPoint.color = new Color(1f, 1f, 1f, .5f);
    }
}
