using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyInstance : MonoBehaviour
{
    public bool firstTime = true;
    private static FireflyInstance instance;

    private void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, set this as the instance and mark it as not to be destroyed on scene load.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one.
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(firstTime == false)
        {
            GameObject fireflyTutorial = GameObject.FindWithTag("FireflyTutorial");
            fireflyTutorial.SetActive(false);
        }
    }
}
