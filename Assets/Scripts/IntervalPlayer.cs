using UnityEngine;
using System.Collections;

public class IntervalPlayer : MonoBehaviour
{
    [System.Serializable]
    public class Interval
    {
        public float duration = 1f;
        public float motorForceSend;
        public float breakForceSend;
        public float horizontalInputSend;
        public float verticalInputSend;
    }

    public Interval[] intervals;

    public float motorForceSent, breakForceSent, horizontalInputSent, verticalInputSent;

    private bool runIntervals = false;
    private bool intervalsActivated = false; // Add this variable

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

    IEnumerator RunIntervals()
    {
        while (runIntervals)
        {
            foreach (var interval in intervals)
            {
                Debug.Log($"Interval: {interval.duration}s, motorForceSend: {interval.motorForceSend}, breakForceSend: {interval.breakForceSend}, horizontalInputSend: {interval.horizontalInputSend}, verticalInputSend: {interval.verticalInputSend}");

                motorForceSent = interval.motorForceSend;
                breakForceSent = interval.breakForceSend;
                horizontalInputSent = interval.horizontalInputSend;
                verticalInputSent = interval.verticalInputSend;

                yield return new WaitForSeconds(interval.duration);
            }

            runIntervals = false; // Set runIntervals to false after all intervals have run
        }
    }
}
