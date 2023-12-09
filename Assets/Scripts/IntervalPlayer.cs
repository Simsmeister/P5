using UnityEngine;
using System.Collections;

public class IntervalPlayer : MonoBehaviour
{
    [System.Serializable]
    public class Interval
    {
        [Tooltip("Duration of this interval")]
        public float duration = 1f;
        public float motorForceSend;
        public float breakForceSend;
        public float horizontalInputSend;
        public float verticalInputSend;
        public bool enableUI;
        public GameObject uIToToggle;
    }

    [System.Serializable]
    public class StartInterval
    {
        [Tooltip("Duration of the start interval")]
        public float duration = 1f;
        public float motorForceSend;
        public float breakForceSend;
        public float horizontalInputSend;
        public float verticalInputSend;
        public bool enableUI;
        public GameObject uIToToggle;
    }

    [Header("Start Intervals")]
    [SerializeField] private StartInterval[] startIntervals;

    [Header("Regular Intervals")]
    [SerializeField] private Interval[] intervals;

    public int intervalCounter = 0;
    public bool waitForInteraction;
    public float motorForceSent, breakForceSent, horizontalInputSent, verticalInputSent;
    private bool runIntervals = false;
    private bool startIntervalsRunning = false; // Added flag for start intervals
    private bool intervalsActivated = false;

    void Start()
    {
        StartCoroutine(RunStartIntervals());
        ActivateIntervals();
    }

    IEnumerator RunStartIntervals()
    {
        startIntervalsRunning = true;

        foreach (var startInterval in startIntervals)
        {
            yield return StartCoroutine(RunSingleInterval(startInterval));
        }

        startIntervalsRunning = false;
    }

    public void ActivateIntervals()
    {
        Debug.Log("ActivateIntervals called");

        if (!intervalsActivated && !startIntervalsRunning) // Check if regular intervals are not already running
        {
            intervalsActivated = true;
            runIntervals = true;
            StartCoroutine(RunIntervals());
        }
        else
        {
            Debug.Log("Intervals already activated or start intervals are running. Can't activate again until scene reloads.");
        }
    }

    public void ButtonPressed()
    {
        if (!intervalsActivated && !startIntervalsRunning) // Check if regular intervals are not already running
        {
            intervalsActivated = true;
            runIntervals = true;
            StartCoroutine(RunIntervals());
        }
        else
        {
            Debug.Log("Intervals already activated or start intervals are running. Can't activate again until scene reloads.");
        }
    }

    public void ToggleUI(GameObject uiToToggle)
    {
        if (uiToToggle.activeSelf == true)
        {
            uiToToggle.SetActive(false);
            waitForInteraction = false;
        }
        else if (uiToToggle.activeSelf == false)
        {
            uiToToggle.SetActive(true);
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

                if (interval.enableUI)
                {
                    ToggleUI(interval.uIToToggle);
                }
            }

            runIntervals = false;
        }
    }

    IEnumerator RunSingleInterval(StartInterval singleInterval)
    {
        Debug.Log($"Start Interval: {singleInterval.duration}s, motorForceSend: {singleInterval.motorForceSend}, breakForceSend: {singleInterval.breakForceSend}, horizontalInputSend: {singleInterval.horizontalInputSend}, verticalInputSend: {singleInterval.verticalInputSend}");

        motorForceSent = singleInterval.motorForceSend;
        breakForceSent = singleInterval.breakForceSend;
        horizontalInputSent = singleInterval.horizontalInputSend;
        verticalInputSent = singleInterval.verticalInputSend;

        yield return new WaitForSeconds(singleInterval.duration);

        if (singleInterval.enableUI)
        {
            ToggleUI(singleInterval.uIToToggle);
        }
    }
}
