using System.Collections;
using UnityEngine;

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
    public void ActivateIntervals()
    {
        Debug.Log("ActivateIntervals called");

        runIntervals = !runIntervals;

        if (runIntervals)
        {
            StartCoroutine(RunIntervals());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public Interval[] intervals;

    public float motorForceSent, breakForceSent, horizontalInputSent, verticalInputSent;

    private bool runIntervals = false;

    /*private void Update()
    {
        // Check for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle the runIntervals flag
            runIntervals = !runIntervals;

            // Start or stop the coroutine based on the flag
            if (runIntervals)
            {
                StartCoroutine(RunIntervals());
            }
            else
            {
                StopAllCoroutines();
            }
        }
    }
    */
    IEnumerator RunIntervals()
    {
        while (runIntervals)
        {
            foreach (var interval in intervals)
            {
                // Do something with interval.variable1 and interval.variable2
                Debug.Log($"Interval: {interval.duration}s, motorForceSend: {interval.motorForceSend}, breakForceSend: {interval.breakForceSend}, horizontalInputSend: {interval.horizontalInputSend}, verticalInputSend: {interval.verticalInputSend}");

                motorForceSent = interval.motorForceSend;
                breakForceSent = interval.breakForceSend;
                horizontalInputSent = interval.horizontalInputSend;
                verticalInputSent = interval.verticalInputSend;

                yield return new WaitForSeconds(interval.duration);
            }
        }
    }
}
