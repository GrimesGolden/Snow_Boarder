using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleController : MonoBehaviour
{
    [SerializeField] ParticleSystem appleEffect;
    ScoreCounter scoreCounter;
    float appleDelay = 0.5f; // This works, even if 0.5f is a bit too long. 
    bool appleHit = false; 

    void Start()
    {
        // Find a GameObject named ScoreCounter in the scene hierarchy.
        GameObject scoreTxt = GameObject.Find("ScoreText");

        // Get the ScoreCounter (Script) component out of scoreGO
        scoreCounter = scoreTxt.GetComponent<ScoreCounter>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !appleHit)
        {
            SoundManager.StopSound(); 
            SoundManager.PlaySound(SoundType.APPLE);
            appleEffect.Play();
            scoreCounter.score += 1;
            appleHit = true; 
            Invoke("DestroyApple", appleDelay); 
      
        }
    }
    
    void DestroyApple()
    {
        Destroy(gameObject); 
    }
}
