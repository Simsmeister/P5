using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntersectionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redLight;
    public Light lightComponent;

    public float stayDuration;

    public float loseTime;

    public GameObject uIToActivate;

    public bool enabledUI;
    void Start()
    {
        lightComponent = redLight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(redLight.GetComponent<Light>().enabled == true)
        {
            if(other.CompareTag("Car"))
            {
                SceneManager.LoadScene("GameOver2");
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(redLight.GetComponent<Light>().enabled == true)
        {
            if(other.CompareTag("Car"))
            {
                stayDuration += Time.deltaTime;
                if(!enabledUI)
                {
                    uIToActivate.SetActive(true);
                    enabledUI = true;
                }

                if(stayDuration >= loseTime)
                {
                    SceneManager.LoadScene("GameOver2");
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            uIToActivate.SetActive(false);
        }
    }

}
