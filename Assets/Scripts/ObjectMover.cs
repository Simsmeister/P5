using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform[] waypoints;   
    public float movementSpeed = 1.0f; 
    public float[] waitTimes;

    public int currentWaypointIndex = 0;
    private float journeyLength;
    private float startTime;
    private bool isWaiting = false;
    private float waitStartTime;
    private bool playedIntro = true;

    private FireflyInstance fireflyInstance;
    public GameObject fireFlyChecker;
    public AudioClip startAudioClip;
    public AudioClip[] audioClips; 
    private AudioSource audioSource;

    void Start()
    {
        if (waypoints.Length != waitTimes.Length)
        {
            Debug.LogError("waypoints and waitTimes arrays must have the same length!");
            return;
        }
        fireFlyChecker = GameObject.FindWithTag("FireflyChecker");
        fireflyInstance = fireFlyChecker.GetComponent<FireflyInstance>();

        // calculates total distance between waypoints
        CalculateJourneyLength();

        startTime = Time.time;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = startAudioClip;
        audioSource.Play(); 
    }
    void Update()
    {
        if (isWaiting)
        {
            if (Time.time - waitStartTime >= waitTimes[currentWaypointIndex])
            {
                isWaiting = false;
                MoveToNextWaypoint();
            }
        }
        else
        {
            // calculatee distance covered based on time passed and speed
            float distanceCovered = (Time.time - startTime) * movementSpeed;

            // calculates fraction of the journey completed
            float fractionOfJourney = distanceCovered / journeyLength;

            if (currentWaypointIndex <= waypoints.Length-2)
            {
                // moves the object using Lerp (Linear Interpolation)
                transform.position = Vector3.Lerp(waypoints[currentWaypointIndex].position, waypoints[currentWaypointIndex + 1].position, fractionOfJourney);
            }
            else if (currentWaypointIndex >= waypoints.Length-1 && playedIntro)
            {
                fireflyInstance.firstTime = false;
                playedIntro = true;
            }
                
            // checks if object has reached the current waypoint
            if (fractionOfJourney >= 1.0f)
            {
                // start waiting at the current waypoint
                isWaiting = true;
                waitStartTime = Time.time;
            }
        }  
    }
    void MoveToNextWaypoint()
    {
        // moves to the next waypoint
        if (currentWaypointIndex <= waypoints.Length-2)
        {
        currentWaypointIndex++;
        }

        // checks if all waypoints have been visited
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            // calculates the total distance between the new waypoints
            CalculateJourneyLength();

            // records the start time for the new journey
            startTime = Time.time;
            PlayAudio();
        }
    }
    void CalculateJourneyLength()
    {
        journeyLength = Vector3.Distance(waypoints[currentWaypointIndex].position, waypoints[currentWaypointIndex + 1].position);
    }

public void PlayAudio()
    {
        // uses switch case statements to play the audio based on the index
        switch (currentWaypointIndex)
        {
            case 0:
                PlayClip(audioClips[0]);
                break;
            case 1:
                PlayClip(audioClips[1]);
                break;
            case 2:
                PlayClip(audioClips[2]);
                break;
            case 3:
                PlayClip(audioClips[3]);
                break;
            case 4:                
                PlayClip(audioClips[4]);
                break;
            case 5:
                PlayClip(audioClips[5]);                
                break;
            case 6:
                PlayClip(audioClips[6]);
                break;
            case 7:
                PlayClip(audioClips[7]);
                break;
            default:
                Debug.Log("Invalid index");
                break;
        }
    }
    private void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Audio clip is null");
        }
    }
}

