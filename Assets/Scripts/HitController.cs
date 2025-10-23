using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{   
    // Simple script to control the enemy hitbox. 
    SlimeController parentScript;

    void Start()
    {
        parentScript = gameObject.GetComponentInParent<SlimeController>(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Board")
        {
            // Add a bounce effect for the player (pushing them back)
            // Make sure to use relative force for an accurate bounce effect.
            // Because we bounce relative to the direction hit. 
            other.attachedRigidbody.AddRelativeForce(Vector2.up * DataManager.I.GetSlimeBounce());
            // Callback and destroy.
            parentScript.DestroySlime(); 
            
        }
    }
}
