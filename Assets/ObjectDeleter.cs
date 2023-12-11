using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
public float deletionDistance = 10f; // Specify the distance beyond which objects should be deleted

    void Update()
    {
        // Find all objects with a specific tag (you can modify this based on your needs)
        GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("NPCWalk");

        // Iterate through each object
        foreach (GameObject obj in objectsToDelete)
        {
            // Calculate the distance between the current object and the object with this script
            float distance = Vector3.Distance(obj.transform.position, transform.position);

            // Check if the distance is beyond the specified deletionDistance
            if (distance > deletionDistance)
            {
                // Destroy the object
                Destroy(obj);
            }
        }
    }
}

