//using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.VisualScripting;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeController : MonoBehaviour
{   
    // Controlling script for all slime enemies and variant types. 
    CrashDetector crashDetector;
    Vector3 slimePos;

    Rigidbody2D slimeBod;

    float t = 1;

    string slimeTag; 

    void Start()
    {
        slimePos = transform.position;
        slimeBod = gameObject.GetComponent<Rigidbody2D>();
        slimeTag = gameObject.tag; 

        if (slimeTag == "Jumpy")
        {
            slimeBod.AddRelativeForce(Vector2.down * DataManager.I.GetSlimeJump());
        }

    }

    void Update()
    {
        if (slimeTag == "Slimy")
        {
            UpdateSlimy();
        }
    }
    
    void UpdateSlimy()
    {
        t += Time.deltaTime; 
        if(t >= 0.5f)
        {
            Attack(); 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Board")
        {   
            // Crash detector handles player side of things. 
            crashDetector = other.gameObject.GetComponent<CrashDetector>();
            crashDetector.ExplodeDucky();
            // Set animator of slime to death anim
            gameObject.GetComponent<Animator>().SetBool("SlimeDead", true);
            DestroySlime();
            // Add a bounce effect
            // Get player rb2d, add a force to it, multiplied by slime bounce (see DataManager.cs)
            slimeBod.AddForce(Vector2.left * DataManager.I.GetSlimeJump());
        }
    }
    
    void Jump()
    {
        // Calculate a jump force multiplied by data manager. 
        slimeBod.AddRelativeForce(Vector2.down * DataManager.I.GetSlimeJump());
    }

    void Attack()
    {
        // The "AI" (not really) for the standard slime variant. 
        t = 0;
        Vector2 jumpForce = Vector2.up * 150;
        Vector2 brakeForce = Vector2.left * 200;
        slimeBod.AddRelativeForce(jumpForce); 
        slimeBod.AddRelativeForce(brakeForce);
    }

    public void DestroySlime()
{
    // Zero out the player's vertical velocity first to avoid stacking with downward momentum.
    //Vector2 currentVel = playerBod.velocity;
    //currentVel.y = 0f;
    //playerBod.velocity = currentVel;

    // Apply a fixed upward impulse for the bounce (consistent, not velocity-based).
    //float bouncePower = DataManager.I.GetSlimeBounce();
    //playerBod.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
    // Move slime to the excluded layer so it won't collide with player anymore.
    gameObject.layer = LayerMask.NameToLayer("Exclude");

    // Play death animation.
    GetComponent<Animator>().SetBool("SlimeDead", true);

    // Schedule destruction.
    Invoke(nameof(DelayedDestroy), DataManager.I.GetSlimeDelay());
}
    
    void DelayedDestroy()
    {
        Destroy(gameObject);
    }
}
