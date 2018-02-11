using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughThePortal : MonoBehaviour {

    public GameObject otherPortal;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I toch a portal");
        if(other.CompareTag("Player"))
        {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 1;
        }
    }

}
