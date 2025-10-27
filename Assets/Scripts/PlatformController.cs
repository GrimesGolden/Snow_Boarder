using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformController : MonoBehaviour
{   
    // Simple controller for the platform. 
    [SerializeField] SurfaceEffector2D mainEffector;
    SurfaceEffector2D myEffector;
    void Start()
    {
        // Speed of floating platforms should match the speed in the rest of the level.
        // Example: if Ducky is boosting, platform speed should also match. 
        myEffector = gameObject.GetComponent<SurfaceEffector2D>();
        myEffector.speed = mainEffector.speed;
    }

    /*
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Instead of updating each frame, use collisions to match speed. 
            myEffector.speed = mainEffector.speed;
        }
    }
    
    */

    void FixedUpdate()
    {
      myEffector.speed = mainEffector.speed; // All platforms mirror the main effector.   
    }
}
