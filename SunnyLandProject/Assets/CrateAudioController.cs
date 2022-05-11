using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateAudioController : MonoBehaviour
{
    AudioSource source;

    public AudioClip wood_impact;
    public AudioClip wood_rumble;

    Rigidbody2D rb;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
// He usado la misma logica que con la cherry

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Box collision detected");
        source.clip = wood_impact;
        source.Play();
    }

    void FixedUpdate()
    {
        float v = rb.velocity.magnitude;
        
        //misma logica que con las footsteps, pero aplicadas al contexto de la crate
        if (v > 1 && !isPlaying){
            source.clip = wood_rumble;
            source.Play();
            isPlaying = true; 
        } 
        else if ( v < 1 && isPlaying){
        source.Stop();
        isPlaying = false;
    }
    }
}
