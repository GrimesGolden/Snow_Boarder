using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;


    void OnCollisionEnter2D(Collision2D other)
    {   
        // If Ducky makes contact with the terrain, play the trail effect. 
        if (other.gameObject.tag == "Terrain")
        {
            snowEffect.Play();
            GetComponent<AudioSource>().Play(); // An accompanying sound effect. 
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Else stop
        snowEffect.Stop();
        GetComponent<AudioSource>().Stop(); // Also pause accompanying sound effect. 
                                            // Note: This plays the standard Ducky slide sound, which is not controlled by the sound manager
                                            // It is instead an Audio Source directly attached to the Ducky game object.  
    }
    
    public void StopTrailSound()
    {
        GetComponent<AudioSource>().Stop();
    }
}
