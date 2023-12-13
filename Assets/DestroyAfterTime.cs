using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 59f;

    void Start()
    {
        // Invoke the DestroyObject method after the specified time
        Invoke("DestroyObject", destroyTime);
    }

    void DestroyObject()
    {
        // Destroy the game object this script is attached to
        Destroy(gameObject);
    }
}
