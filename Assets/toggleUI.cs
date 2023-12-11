using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleUI : MonoBehaviour
{

    public bool testBool = false;
    public bool testFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(testBool && !testFlag)
        {
            ToggleUIFirst();
            testFlag = true;
        }
    }

    public void ToggleUIFirst()
    {
        IntervalPlayer intervalPlayer = this.gameObject.GetComponent<IntervalPlayer>();
        if (intervalPlayer.intervals[intervalPlayer.intervalCounterFirst-1].uIToToggle.activeSelf == true)
        {
            intervalPlayer.intervals[intervalPlayer.intervalCounterFirst-1].uIToToggle.SetActive(false);
            StartCoroutine(intervalPlayer.RunSecondIntervals());
            intervalPlayer.waitForInteractionFirst = false;
        }
    }

    public void ToggleUISecond()
    {
        IntervalPlayer intervalPlayer = this.gameObject.GetComponent<IntervalPlayer>();
        if (intervalPlayer.secondIntervals[intervalPlayer.intervalCounterSecond-1].uIToToggle.activeSelf == true)
        {
            intervalPlayer.secondIntervals[intervalPlayer.intervalCounterSecond-1].uIToToggle.SetActive(false);
            StartCoroutine(intervalPlayer.RunThirdIntervals());
            intervalPlayer.waitForInteractionSecond = false;
        }
    }
}
