using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{ 
    // mis AudioSources, organizadas para el main mixer
    AudioSource runningSource;
    AudioSource crouchingSource;
    AudioSource jumpSource;
    AudioSource cherrySource;
    AudioSource landingSource;

    //audio clips que uso
    public AudioClip RunningGrass;
    public AudioClip crouch;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip landing1;
    public AudioClip landing2;
    public AudioClip landing3;
    public AudioClip cherry;

    // keep track of the jumping state ... 
    bool isJumping = false;
    // make sure to keep track of the movement as well !
   // bool isMoving = false; // movimiento en general, usar con ismoving y !isJumping. son dos cosas diferentes
    
    bool isPlaying = false;

    Rigidbody2D rb; // note the "2D" prefix 
    
    // Start is called before the first frame update
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	// get the references to your audio sources here ! 
    // como tengo varias audiosources: []   
    runningSource = GetComponents<AudioSource>()[0];    
    crouchingSource = GetComponents<AudioSource>()[1];
    jumpSource = GetComponents<AudioSource>()[2];   
    cherrySource = GetComponents<AudioSource>()[3];
    landingSource = GetComponents<AudioSource>()[4];
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }	

// intento fallido :D
   // if(GetComponent<Rigidbody2D>().velocity.magnitude > 1){
       //Debug.Log("Fox is Moving");
    //     }

    float v = rb.velocity.magnitude; // la v es mi variable para representar la velocidad de movimiento

    // Cuando está en movimiento, no hay sonido y no hay salto. Suena el sonido de footsteps.
    if (v > 1 && !isPlaying && !isJumping){
        runningSource.clip = RunningGrass;
        runningSource.Play();
        isJumping = false;
        isPlaying = true; 
    } 
    // Cuando no se mueve se debe parar el sonido de footsteps
    else if ( v < 1 && isPlaying){
        runningSource.Stop();
        isPlaying = false;

    } 
    // Si está saltando el sonido también debe parar
    else if (isJumping){ 
        runningSource.Stop();
        isJumping = true;
    }


    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        isJumping = false;
        print("the fox has landed");
         //landingSource.clip = landing1;
           // landingSource.Play();

       // 3 posibilidades reproducen 3 clips basados en un Random Range.
        int choiceValue = Random.Range(-1, 2);
        if (choiceValue > 0 ){
          landingSource.clip = landing1;
            landingSource.Play();
            print("landing 1 clip");
        }
        else if(choiceValue == 0){         // = 0 cree que es boolean cuando no
            landingSource.clip = landing2;
            landingSource.Play();
            print("landing 2 clip");
        }
       else if(choiceValue < 0){
            landingSource.clip = landing3;
            landingSource.Play();
            print("landing 3 clip");
        }
        
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumped ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        print("the fox is crouching");
        crouchingSource.clip = crouch;
        crouchingSource.Play();

    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        isJumping = true;
        print("the fox has jumped");
        // 2 posibilidades y 2 clips
        int choiceValue = Random.Range(-1, 1);
        if (choiceValue < 0 ){
          jumpSource.clip = jump1;
            jumpSource.Play();
            print("jump 1 clip");
            
        } else if(choiceValue == 0){
          jumpSource.clip = jump2;
            jumpSource.Play();
            print("jump 2 clip");
            
        }
        
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        print("the fox has collected a cherry");
        cherrySource.clip = cherry;
        cherrySource.Play();
    }
}
