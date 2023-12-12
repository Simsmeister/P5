using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyUpdater : MonoBehaviour
{
    public GameObject fireflyChecker;
    public GameObject fireflyFail;
    // Start is called before the first frame update
    void Start()
    {
        fireflyChecker = GameObject.FindWithTag("FireflyChecker");
        FireflyInstance fireflyInstance = fireflyChecker.GetComponent<FireflyInstance>();
        if(fireflyInstance.firstTime == false)
        {
            GameObject fireflyTutorial = GameObject.FindWithTag("FireflyTutorial");
            fireflyTutorial.SetActive(false);
            fireflyFail.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
