using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAppear : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;
        float TheDistace;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        // Find all game objects with the "Menu" tag
        GameObject[] menuObjects = GameObject.FindGameObjectsWithTag("Menu");

        bool hitMenu = false; // Flag to check if the ray hits a "Menu" object

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            TheDistace = hit.distance;
            print(TheDistace + " " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Menu"))
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                hitMenu = true; // Ray hits a "Menu" object
            }
        }

        // If the ray didn't hit any "Menu" object, disable MeshRenderer for all "Menu" objects
        if (!hitMenu)
        {
            foreach (GameObject menuObject in menuObjects)
            {
                menuObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
