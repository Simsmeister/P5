//https://www.youtube.com/watch?v=k9FvVwd5pR4&ab_channel=Nelson_GD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    public GameObject car;

    private Vector3 startPos;

    private Vector3 endPos;

    public float distance;

    public float lerpTime;

    private float currentLerpTime = 0;

    private bool keyHit = false;

    void Start()
    {
        startPos = car.transform.position;
        endPos = car.transform.position + Vector3.forward * distance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyHit = true;
        }
    
    if (keyHit == true) {
    
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime >= lerpTime) {
        currentLerpTime = lerpTime;
        }
        float Perc = currentLerpTime / lerpTime;
        car.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }
    }
}
