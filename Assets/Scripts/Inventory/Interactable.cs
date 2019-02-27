using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    private Transform player;
    private bool hasInteracted = false;
    
    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with: " + transform.name);
    }
    
    void Update()
    {
        var distance = Vector3.Distance(player.transform.position, transform.position);
        if (!(distance <= radius) || hasInteracted) return;
        Interact();
        hasInteracted = true;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
