using UnityEngine;

public class SpawnAndMovePrefab : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 10f;
    public float movementSpeed = 1f;

    public float spawnStartTime;

    private float timer = 0f;

    void Start()
    {
        InvokeRepeating("SpawnPrefabInstance", spawnStartTime, 28f);
    }
    
    void Update()
    {
        /*timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefabInstance();
            timer = 0f;
        }*/
    }

    void SpawnPrefabInstance()
    {
        // Instantiate the prefab
        GameObject prefabInstance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        // Attach a script to control movement
        MovementScript movementScript = prefabInstance.AddComponent<MovementScript>();

        // Set the movement speed
        movementScript.speed = movementSpeed;
    }
}

public class MovementScript : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        // Move the object along the negative Z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
