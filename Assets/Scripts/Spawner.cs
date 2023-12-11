using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    private GameObject lastInstantiatedObject;
    public float spawnInterval;
    public float rotationAmount;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3f, spawnInterval);
    }


    public void Spawn()
    {
        lastInstantiatedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        lastInstantiatedObject.transform.Rotate(0f, rotationAmount, 0f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
