using UnityEngine;

public class BlinkerController : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float colorChangeSpeed = 1;
    public AudioClip blinkerSound;

    private Renderer ren;
    private AudioSource audioSource;
    private bool insideBlinkerBox = false;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = blinkerSound;
        audioSource.loop = true; // Adjust as needed
        audioSource.playOnAwake = false;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlinkerBox"))
        {
            insideBlinkerBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlinkerBox"))
        {
            insideBlinkerBox = false;
        }
    }
}
