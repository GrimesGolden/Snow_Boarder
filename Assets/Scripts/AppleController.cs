using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleController : MonoBehaviour
{   
    // Controlling script for the apple pickup which updates score. 
    // CoffeeController is essentially the same with small differences associated with boost value. See CoffeeController.cs

   // DataManager dataManager; 
    [SerializeField] ParticleSystem appleEffect; // The associated particle effect

    [SerializeField] Animator animator; // The associated sprite animation

    int appleValue; // How many scoring points an apple is worth
    ScoreCounter scoreCounter;
    float appleDelay; // How long a pickup should hold before destruction after pickup
    bool appleHit = false; 

    void Start()
    {
        LoadData(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        // On trigger if hit by a player, act accordingly. 
        if (other.tag == "Player" && !appleHit)
        {
            UpdateSounds();
            UpdateValues(); 
            Invoke("DestroyApple", appleDelay); // Invoke after a short delay to give pickup effects/animation time to display. 

        }
    }
    
    void UpdateSounds()
    {   
        // Play associated sound using SoundManager
        SoundManager.StopSound();
        SoundManager.PlaySound(SoundType.APPLE);
    }

    void UpdateValues()
    {
        appleEffect.Play();
        scoreCounter.score += appleValue;
        appleHit = true; // This prevents double triggers for pickups. 
        animator.SetBool("collect", true); // See the animator controller, this triggers the associated state transition. 
    }
    
    void LoadData()
    {  
       // Find a GameObject named ScoreCounter in the scene hierarchy.
        GameObject scoreDisplay = GameObject.Find("ScoreDisplay");

        // Get the ScoreCounter (Script) component out of scoreGO
        scoreCounter = scoreDisplay.GetComponent<ScoreCounter>();

        // Load values from DataManager script into prefab values.
        appleValue = DataManager.I.GetAppleVal();
        appleDelay = DataManager.I.GetAppleDelay(); 
    }
    
    void DestroyApple()
    {
        Destroy(gameObject); 
    }
}
