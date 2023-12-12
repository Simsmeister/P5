using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform[] waypoints;   // Assign the waypoints in the Inspector
    public float movementSpeed = 1.0f; // Adjust the movement speed in the Inspector
    public float waitTime = 3.0f; // Adjust the wait time in the Inspector

    public int currentWaypointIndex = 0;
    private float journeyLength;
    private float startTime;
    private bool isWaiting = false;
    private float waitStartTime;

    public AudioClip[] audioClips; // Array to hold the audio clips
    private AudioSource audioSource; // AudioSource component

    void Start()
    {
        // Calculate the total distance between waypoints
        CalculateJourneyLength();

        // Record the start time
        startTime = Time.time;

        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isWaiting)
        {
            // Check if the wait time has passed
            if (Time.time - waitStartTime >= waitTime)
            {
                isWaiting = false;
                MoveToNextWaypoint();
            }
        }
        else
        {
            // Calculate the distance covered based on time passed and speed
            float distanceCovered = (Time.time - startTime) * movementSpeed;

            // Calculate the fraction of the journey completed
            float fractionOfJourney = distanceCovered / journeyLength;

            // Move the object using Lerp (Linear Interpolation)
            transform.position = Vector3.Lerp(waypoints[currentWaypointIndex].position, waypoints[currentWaypointIndex + 1].position, fractionOfJourney);

            // Check if the object has reached the current waypoint
            if (fractionOfJourney >= 1.0f)
            {
                // Start waiting at the current waypoint
                isWaiting = true;
                waitStartTime = Time.time;
            }
        }
    }

    void MoveToNextWaypoint()
    {
        // Move to the next waypoint
        currentWaypointIndex++;

        // Check if all waypoints have been visited
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            // Calculate the total distance between the new waypoints
            CalculateJourneyLength();
            
            // Record the start time for the new journey
            startTime = Time.time;
            PlayAudio();
        }
        else
        {
            // Optionally, you can perform additional actions when all waypoints are visited
            // For example, reset the movement to loop through waypoints again
            // currentWaypointIndex = 0;
            // startTime = Time.time;
        }
    }

    void CalculateJourneyLength()
    {
        journeyLength = Vector3.Distance(waypoints[currentWaypointIndex].position, waypoints[currentWaypointIndex + 1].position);
    }

public void PlayAudio()
    {
        // Use a switch case statement to play the audio based on the index
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
            // Add more cases as needed for each audio clip
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

