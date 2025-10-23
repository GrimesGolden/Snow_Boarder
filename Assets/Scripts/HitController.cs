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
            // Callback and destroy. 
            //other.attachedRigidbody.AddForce()
            parentScript.DestroySlime(); 
            
        }
    }
}
