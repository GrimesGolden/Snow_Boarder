using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    [SerializeField] ParticleSystem boostEffect;
    [SerializeField] Animator animator;

    [SerializeField] int boostAmount = 25; 
    BoostCounter boostCounter;
    float coffeeDelay = 0.5f;
    bool coffeeHit = false; 
    void Start()
    {
         // Find a GameObject named ScoreCounter in the scene hierarchy.
        GameObject boostTxt = GameObject.Find("BoostText");

        // Get the ScoreCounter (Script) component out of scoreGO
        boostCounter = boostTxt.GetComponent<BoostCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !coffeeHit)
        {
            SoundManager.StopSound();
            SoundManager.PlaySound(SoundType.COFFEE);
            boostEffect.Play();
            boostCounter.boostVal += boostAmount; 
            coffeeHit = true;
            animator.SetBool("collect", true);
            Invoke("DestroyCoffee", coffeeDelay);

        }
    }
    
    void DestroyCoffee()
    {
        Destroy(gameObject); 
    }
}
