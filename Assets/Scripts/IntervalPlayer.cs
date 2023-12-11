using UnityEngine;
using System.Collections;
public class IntervalPlayer : MonoBehaviour
{
    [System.Serializable]
    public class Interval
    {
        [Tooltip("Duration of this interval")]
        public float duration = 1f;
        [Tooltip("Speed")]
        public float motorForceSend;
        [Tooltip("Breakforce")]
        public float breakForceSend;
        [Tooltip("Left and Right value")]
        public float horizontalInputSend;
        [Tooltip("Up and down value")]
        public float verticalInputSend;
        [Tooltip("Enabling this, toggles your chosen UI at the end of this interval")]
        public bool enableUI;
        [Tooltip("Drag your UI here if a toggle is desired. Drag the object holding this script onto the button interactions and choose the ToggleUI function to toggle the UI off when button is pressed")]
        public GameObject uIToToggle;
    }

    public Interval[] intervals;

    public Interval[] secondIntervals;

    public Interval[] thirdIntervals;


    // keeps track of the active interval. is updated in the RunIntervals coroutine
    public int intervalCounterFirst, intervalCounterSecond, intervalCounterThird;
    // flag to determine whether the coroutine should put its loop on hold to wait for UI interaction. is updated inside the ToggleUI function
    public bool waitForInteractionFirst, waitForInteractionSecond, waitForInteractionThird;

    //variables for car logic
    public float motorForceSent, breakForceSent, horizontalInputSent, verticalInputSent;
    // flag to determine whether coroutine should run
    private bool runIntervals = true;
    private bool intervalsActivated = false;

    // Is used inside if-statements but can't remember why

    void Start()
    {
        StartCoroutine(RunFirstIntervals());
    }
    public void ActivateIntervals()
    {
        Debug.Log("ActivateIntervals called");
        if (!intervalsActivated)
        {
            intervalsActivated = true; // Mark intervals as activated
            runIntervals = true; // Set runIntervals to true
            StartCoroutine(RunFirstIntervals());
        }
        else
        {
            Debug.Log("Intervals already activated. Can't activate again until scene reloads.");
        }
    }
    public void ButtonPressed()
    {
        if (!intervalsActivated)
        {
            intervalsActivated = true; // Mark intervals as activated
            runIntervals = true; // Set runIntervals to true
            StartCoroutine(RunFirstIntervals());
        }
        else
        {
            Debug.Log("Intervals already activated. Can't activate again until scene reloads.");
        }
    }
    public void ToggleUIFirst()
    {

        if (intervals[intervalCounterFirst].uIToToggle.activeSelf == false)
        {
            intervals[intervalCounterFirst].uIToToggle.SetActive(true);
            waitForInteractionFirst = true;
        }
    }

    public void ToggleUISecond()
    {

        if (secondIntervals[intervalCounterSecond].uIToToggle.activeSelf == false)
        {
            secondIntervals[intervalCounterSecond].uIToToggle.SetActive(true);
        }
    }
            
        

    
    IEnumerator RunFirstIntervals()
    {
        while (runIntervals)
        {
            foreach (var interval in intervals)
            {
                if (!waitForInteractionFirst)
                {
                    Debug.Log($"Interval: {interval.duration}s, motorForceSend: {interval.motorForceSend}, breakForceSend: {interval.breakForceSend}, horizontalInputSend: {interval.horizontalInputSend}, verticalInputSend: {interval.verticalInputSend}");
                    motorForceSent = interval.motorForceSend;
                    breakForceSent = interval.breakForceSend;
                    horizontalInputSent = interval.horizontalInputSend;
                    verticalInputSent = interval.verticalInputSend;

                    yield return new WaitForSeconds(interval.duration);
                    if(intervals[intervalCounterFirst].enableUI == true)
                    {
                        ToggleUIFirst();
                    }
                    intervalCounterFirst++;
                }
                else 
                {
                    horizontalInputSent = 0;
                    verticalInputSent = 0;
                    //StopCoroutine(RunFirstIntervals());
                    yield break;
                    
                }
                 
            }
            //runIntervals = false; // Set runIntervals to false after all intervals have run
            //StopCoroutine(RunFirstIntervals());
        }
    }

    public IEnumerator RunSecondIntervals()
    {
        while (runIntervals)
        {
            foreach (var secondInterval in secondIntervals)
            {
                if (!waitForInteractionSecond)
                {
                    Debug.Log($"Interval: {secondInterval.duration}s, motorForceSend: {secondInterval.motorForceSend}, breakForceSend: {secondInterval.breakForceSend}, horizontalInputSend: {secondInterval.horizontalInputSend}, verticalInputSend: {secondInterval.verticalInputSend}");
                    motorForceSent = secondInterval.motorForceSend;
                    breakForceSent = secondInterval.breakForceSend;
                    horizontalInputSent = secondInterval.horizontalInputSend;
                    verticalInputSent = secondInterval.verticalInputSend;

                    yield return new WaitForSeconds(secondInterval.duration);
                    if(secondIntervals[intervalCounterSecond].enableUI == true)
                    {
                        ToggleUISecond();
                    }
                    intervalCounterSecond++;
                }
                else 
                {
                    yield break;
                    
                }
                 
            }
            //runIntervals = false; // Set runIntervals to false after all intervals have run
        }
    }

    public IEnumerator RunThirdIntervals()
    {
        while (runIntervals)
        {
            foreach (var thirdInterval in thirdIntervals)
            {
                if (!waitForInteractionThird)
                {
                    Debug.Log($"Interval: {thirdInterval.duration}s, motorForceSend: {thirdInterval.motorForceSend}, breakForceSend: {thirdInterval.breakForceSend}, horizontalInputSend: {thirdInterval.horizontalInputSend}, verticalInputSend: {thirdInterval.verticalInputSend}");
                    motorForceSent = thirdInterval.motorForceSend;
                    breakForceSent = thirdInterval.breakForceSend;
                    horizontalInputSent = thirdInterval.horizontalInputSend;
                    verticalInputSent = thirdInterval.verticalInputSend;

                    yield return new WaitForSeconds(thirdInterval.duration);
                    /*if(afterSecondUIIntervals[intervalCounterThird].enableUI == true)
                    {
                        ToggleUISecond();
                    }*/
                    intervalCounterThird++;
                }
                else 
                {
                    horizontalInputSent = 0;
                    verticalInputSent = 0;
                    yield return null;
                    
                }
                 
            }
            //runIntervals = false; // Set runIntervals to false after all intervals have run
        }
    }
}