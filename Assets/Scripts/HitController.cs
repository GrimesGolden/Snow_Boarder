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
            gameObject.GetComponentInParent<BoxCollider2D>().enabled = false; // No double bounce please.
            gameObject.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition; // freeze position
            // Callback and destroy.
            parentScript.DestroySlime(); 
            
        }
    }
}
