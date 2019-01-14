using UnityEngine;
using System.Collections;

public class CameraMoves : MonoBehaviour
{
    public float speed;
    public Camera Camera;

    public void Start()
    {

    }
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.N))
        {
            Camera.orthographicSize++;
        }
    }
}