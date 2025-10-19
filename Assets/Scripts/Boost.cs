using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost : MonoBehaviour
{
    // This script handles the gameplay of the boosting ability. 
    // The tracking/counting is handled by BoostCounter.cs

    //DataManager dataManager;
    int boostRemaining;
    [SerializeField] ParticleSystem boostEffect; // This needs to be serialized because there are many possible boost effects.

    Animator animator; 
    float boostDelay;
    float t = 1; // It doesn't matter what number we initialize, so long as it's >= 1. 
    BoostCounter boostCounter; 
    void Start()
    {
        LoadData(); 
    }

    void Update()
    {
        // update the tracking time. 
        // Tracks how long we are boosting for. 
        t += Time.deltaTime;
    }
    
    void LoadData()
    {   
        // Find a GameObject named BoostManager in the scene hierarchy.
        GameObject boostManager = GameObject.Find("BoostManager");
        // Load values from DataManager script into prefab values. 
        GameObject gameManager = GameObject.Find("GameManager");
        // Get the BoostCounter.cs script out of BoostManager
        boostCounter = boostManager.GetComponent<BoostCounter>();
        boostRemaining = boostCounter.GetBoostCount();
        //dataManager = gameManager.GetComponentInChildren<DataManager>();
        animator = GetComponentInChildren<Animator>(); 
        boostDelay = DataManager.I.GetBoostDelay(); 
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
            // Update sprite animations.
            animator.SetFloat("Speed", speedIncrease); 
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
            animator.SetFloat("Speed", baseSpeed); // Add a walking animation when braking. 
        }
    }
}
