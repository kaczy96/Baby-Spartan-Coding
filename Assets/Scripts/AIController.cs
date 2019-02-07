using System.Collections;
using UnityEditor;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float stoppingDistance;
    Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position ) > stoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        
    }

    

    
}
