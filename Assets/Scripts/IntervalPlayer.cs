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
    // keeps track of the active interval. is updated in the RunIntervals coroutine
    public int intervalCounter = 0;
    // flag to determine whether the coroutine should put its loop on hold to wait for UI interaction. is updated inside the ToggleUI function
    public bool waitForInteraction;
    //variables for car logic
    public float motorForceSent, breakForceSent, horizontalInputSent, verticalInputSent;
    // flag to determine whether coroutine should run
    private bool runIntervals = false;
    // Is used inside if-statements but can't remember why
    private bool intervalsActivated = false; 

    public void ActivateIntervals()
    {
        Debug.Log("ActivateIntervals called");

        if (!intervalsActivated)
        {
            intervalsActivated = true; // Mark intervals as activated
            runIntervals = true; // Set runIntervals to true
            StartCoroutine(RunIntervals());
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
            StartCoroutine(RunIntervals());
        }
        else
        {
            Debug.Log("Intervals already activated. Can't activate again until scene reloads.");
        }
    }

    public void ToggleUI()
    {
        if (intervals[intervalCounter].uIToToggle.activeSelf == true)
        {
            intervals[intervalCounter].uIToToggle.SetActive(false);
            waitForInteraction = false;
        }
        else if (intervals[intervalCounter].uIToToggle.activeSelf == false)
        {
            intervals[intervalCounter].uIToToggle.SetActive(true);
            waitForInteraction = true;
        }
    }

    IEnumerator RunIntervals()
    {
        while (runIntervals)
        {
            foreach (var interval in intervals)
            {
                if (!waitForInteraction)
                Debug.Log($"Interval: {interval.duration}s, motorForceSend: {interval.motorForceSend}, breakForceSend: {interval.breakForceSend}, horizontalInputSend: {interval.horizontalInputSend}, verticalInputSend: {interval.verticalInputSend}");

                motorForceSent = interval.motorForceSend;
                breakForceSent = interval.breakForceSend;
                horizontalInputSent = interval.horizontalInputSend;
                verticalInputSent = interval.verticalInputSend;

                yield return new WaitForSeconds(interval.duration);
                intervalCounter++;

                if(intervals[intervalCounter].enableUI == true)
                {
                    ToggleUI();
                }
            }

            runIntervals = false; // Set runIntervals to false after all intervals have run
        }
    }
}
