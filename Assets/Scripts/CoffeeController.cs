using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    [SerializeField] ParticleSystem boostEffect;
    [SerializeField] Animator animator;

    [SerializeField] int boostAmount = 25;
    [SerializeField] float coffeeDelay = 0.5f;

     BoostCounter boostCounter; 
    bool coffeeHit = false; 
    void Start()
    {
         // Find a GameObject named BoostManager in the scene hierarchy.
        GameObject boostManager = GameObject.Find("BoostManager");

        // Get the boostCounter (Script) component out of BoostManager
        boostCounter = boostManager.GetComponent<BoostCounter>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !coffeeHit)
        {
            UpdateSounds();
            UpdateValues(); 
            Invoke("DestroyCoffee", coffeeDelay);

        }
    }

    void UpdateSounds()
    {
        SoundManager.StopSound();
        SoundManager.PlaySound(SoundType.COFFEE);
    }
    
    void UpdateValues()
    {
        boostEffect.Play();
        boostCounter.AddBoostCount(boostAmount);

        coffeeHit = true;
        animator.SetBool("collect", true);
    }
    
    void DestroyCoffee()
    {
        Destroy(gameObject); 
    }
}
