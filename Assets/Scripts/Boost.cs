using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost : MonoBehaviour
{   
    // This script handles the gameplay of the boosting ability. 
    // The tracking/counting is handled by BoostCounter.cs
    int boostRemaining; 
    [SerializeField] ParticleSystem boostEffect;
    [SerializeField] float boostDelay = 0.2f;
    float t = 1; // It doesn't matter what number we initialize, so long as it's >= 1. 
    BoostCounter boostCounter; 
    void Start()
    {
        // Find a GameObject named BoostManager in the scene hierarchy.
        GameObject boostManager = GameObject.Find("BoostManager");

        // Get the BoostCounter.cs script out of BoostManager
        boostCounter = boostManager.GetComponent<BoostCounter>();

        boostRemaining = boostCounter.GetBoostCount(); 
    }
    
    void Update()
    {   
        // update the tracking time. 
        // Tracks how long we are boosting for. 
        t += Time.deltaTime; 
    }

    public void HandleBoost(SurfaceEffector2D player, float speedIncrease, float baseSpeed)
    {
        // We first need to update the boost available.
        boostRemaining = boostCounter.GetBoostCount();
        
        // If we can boost, and the trigger time delay has reset, then...
        if (t >= boostDelay && boostRemaining > 0)
        {
            // Reduce the boost count by 1. 
            boostCounter.SubBoostCount(1);
            // Increase the players speed by the given boost amount. 
            player.speed = speedIncrease;
            // Play the particle effect. 
            boostEffect.Play();
            // Resetting prevents eccessive spamming of the boost. 
            t = 0;
        }
        else if (t <= boostDelay && boostRemaining <= 0)
        {
            // If the time hasn't reset, but the boost has been depleted.
            // Reset the speed. 
            // This prevents gameplay in which, while the player holds down W, boost is infinite. 
            player.speed = baseSpeed; 
        }
    }
}
