using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{   
    // Simple controller for the platform. 
    [SerializeField] SurfaceEffector2D mainEffector;
    SurfaceEffector2D myEffector;

    float maxHeight;
    float maxDepth;

    bool switchDirections = false; 

    void Start()
    {
        // Speed of floating platforms should match the speed in the rest of the level.
        // Example: if Ducky is boosting, platform speed should also match. 
        myEffector = gameObject.GetComponent<SurfaceEffector2D>();
        myEffector.speed = mainEffector.speed;
        maxHeight = gameObject.transform.position.y + 10f; // Magic number
        maxDepth = gameObject.transform.position.y; 
    }

  //  void OnCollisionEnter2D(Collision2D other)
  //  {
 //       if (other.gameObject.tag == "Player")
   //     {
   //         // Instead of updating each frame, use collisions to match speed. 
    //        myEffector.speed = mainEffector.speed;
   //     }
 //   }
  //  
    void FixedUpdate()
    {   
        // Time independant. 
        Vector2 oldPos = gameObject.transform.position;

        if (!switchDirections)
        {
            Vector2 newPos = oldPos;
            newPos.y += DataManager.I.GetPlatformRate() * Time.deltaTime;
            if (newPos.y >= maxHeight)
            {
                switchDirections = true;
            }
            gameObject.transform.position = newPos;
        }
        else if (switchDirections)
        {
            Vector2 newPos = oldPos;
            newPos.y -= DataManager.I.GetPlatformRate() * Time.deltaTime;
            if (newPos.y <= maxDepth)
            {
                switchDirections = false;
            }
            gameObject.transform.position = newPos;
        }
        
        myEffector.speed = mainEffector.speed; // Finally match the speed of the effector to the main sprite shape. 
    }
}
