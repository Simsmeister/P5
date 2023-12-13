using UnityEngine;

public class BlinkerControllerOther : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float colorChangeSpeed = 1;
    public AudioClip blinkerSound;

    private Renderer ren;
    private AudioSource audioSource;
    private bool insideBlinkerBox = false;
    private float targetVolume = 0.2f; // Default volume level

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = blinkerSound;
        audioSource.loop = true; // Adjust as needed
        audioSource.playOnAwake = false;
        audioSource.volume = targetVolume; // Set initial volume
    }

    private void Update()
    {
        if (insideBlinkerBox)
        {
            ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * colorChangeSpeed, 1));

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        // Adjust volume dynamically
        audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, Time.deltaTime * 5.0f);
    }

    // Function to set the target volume
    public void SetVolume(float volume)
    {
        targetVolume = Mathf.Clamp01(volume);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlinkerBoxOther"))
        {
            insideBlinkerBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlinkerBoxOther"))
        {
            insideBlinkerBox = false;
        }
    }
}
