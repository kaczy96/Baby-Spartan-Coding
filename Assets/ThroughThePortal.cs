using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughThePortal : MonoBehaviour {

    public GameObject otherPortal;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I toch a portal");
        if(other.tag == "Player")
        {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 1;
        }
    }

}
