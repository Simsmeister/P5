using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // Reference to the car prefab you want to instantiate.

    private GameObject lastInstantiatedCar;

    public float rotationAmount;
    void Start()
    {
        // Invoke the SpawnCar method every 30 seconds, starting after 0 seconds.
        InvokeRepeating("SpawnCar", 0f, 30f);
    }

    void SpawnCar()
    {
        // Instantiate a car at the position of the GameObject holding this script.
        lastInstantiatedCar = Instantiate(carPrefab, transform.position, Quaternion.identity);
        lastInstantiatedCar.transform.Rotate(0f, rotationAmount, 0f);
    }
    public GameObject GetLastInstantiatedCar()
    {
        return lastInstantiatedCar;
    }
}