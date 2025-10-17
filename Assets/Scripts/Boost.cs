using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    BoostCounter boostCounter;
    [SerializeField] ParticleSystem boostEffect;
    float t;
    void Start()
    {
        // Find a GameObject named ScoreCounter in the scene hierarchy.
        GameObject boostTxt = GameObject.Find("BoostText");

        // Get the ScoreCounter (Script) component out of scoreGO
        boostCounter = boostTxt.GetComponent<BoostCounter>();
        t = 5; // It doesn't matter what number we use to start, so long as it's >= 1. 
    }
    
    void Update()
    {   
        // update the tracking time. 
        t += Time.deltaTime; 
    }

    public void HandleBoost( SurfaceEffector2D player, float speed)
    {
        if (boostCounter.boostVal > 0) // This doesn't need to be a public val like this, but it works. Score counter does the same thing.
        {
            --boostCounter.boostVal;
            player.speed = speed;
            boostEffect.Play(); 
        }
        else if (t >= 1)
        {   
            // This prevents eccessive spamming of the sound. 
            t = 0;
            //SoundManager.PlaySound(SoundType.ERROR);
            Debug.Log(t);
        }
        else
        {
            // Didn't trigger because t is too short. 
        }
    }
}
