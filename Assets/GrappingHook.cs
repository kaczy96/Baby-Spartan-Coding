using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappingHook : MonoBehaviour {

    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask hookable;

	void Start ()
    {
       joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            var direction = targetPos - transform.position;
            direction.Normalize();

            hit = Physics2D.Raycast(transform.position, direction, distance, hookable);

            if (hit.collider != null)
            {
                print("a");

                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);
            }

            

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            joint.enabled = false;
        }
    }
}
