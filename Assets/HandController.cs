using UnityEngine;

public class HandController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("DriveButton"))
            Debug.Log("HandController OnTriggerEnter");

        {
            // Find the IntervalPlayer script in the scene
            IntervalPlayer intervalPlayer = FindObjectOfType<IntervalPlayer>();

            // Activate the intervals
            if (intervalPlayer != null)
            {
                intervalPlayer.ActivateIntervals();
            }
            else
            {
                Debug.LogWarning("IntervalPlayer script not found.");
            }
        }
    }
}
