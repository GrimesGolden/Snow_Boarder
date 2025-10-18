using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    int boostRemaining = 0; 
    [SerializeField] ParticleSystem boostEffect;
    [SerializeField] float boostDelay = 0.2f;
    float t = 1; // It doesn't matter what number we initialize, so long as it's >= 1. 
    BoostCounter boostCounter; 
    void Start()
    {
        // Find a GameObject named ScoreCounter in the scene hierarchy.
        GameObject boostManager = GameObject.Find("BoostManager");

        // Get the ScoreCounter (Script) component out of scoreGO
        boostCounter = boostManager.GetComponent<BoostCounter>();
    }
    
    void Update()
    {   
        // update the tracking time. 
        t += Time.deltaTime; 
    }

    public void HandleBoost(SurfaceEffector2D player, float speedIncrease, float baseSpeed)
    {
        boostRemaining = boostCounter.GetBoostCount();
        Debug.Log("Boost Remaining: " + boostRemaining);
        if (t >= boostDelay && boostRemaining > 0)
        // Triggers only after a time trigger and if there is boost remaining. 
        // But come to think of it why does the boost counter hold the boost?! A: because it counts the boost and manages it in a central location. 
        // Otherwise we play pass the parcel with the boost amount. 
        {
            //Debug.Log("Handling boost, inside if!");
            boostCounter.SubBoostCount(1);
            player.speed = speedIncrease;
            boostEffect.Play();
            // This prevents eccessive spamming of the boost. 
            t = 0;
        }
        else if (t <= boostDelay && boostRemaining <= 0)
        {
            Debug.Log("OUT OF BOOST.");
            player.speed = baseSpeed; // This way if the player holds down W, it still detects. 
        }
    }
}
