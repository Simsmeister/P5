using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    // Function called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding GameObject has the tag "EntityDespawn"
        if (collision.gameObject.CompareTag("EntityDespawn"))
        {
            // Destroy the GameObject
            Destroy(gameObject);
        }
    }
}
