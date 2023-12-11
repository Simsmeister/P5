using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngineAudio : MonoBehaviour
{

    public Rigidbody rb;
    public AudioSource engineAudio;

    public float pitchMultiplier = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        engineAudio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float pitch = 1.0f + Mathf.Abs(rb.velocity.magnitude) * pitchMultiplier;
        pitch = Mathf.Clamp(pitch, 1.0f, 3.0f);

        engineAudio.pitch = pitch;
        
    }
}
