using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour {
    public Camera cam;
    public GameObject leftPortal;
    public GameObject rightPortal;

	void Start () {
		
	}
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click");
            throwPortal(leftPortal);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click");
            throwPortal(rightPortal);
        }

    }

    void throwPortal(GameObject portal)
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
            portal.transform.position = hit.point;
            portal.transform.rotation = hitObjectRotation;
        }
            

    }

}
