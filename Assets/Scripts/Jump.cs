using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{   
    // Handles the gameplay of jumping. 
    bool canJump = false;

    const float dragForce = 5; // This is needed to make the jump affect play with more realism. 
     void OnCollisionEnter2D(Collision2D other)
    {   
        // Can only jump from ground. 
        canJump = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Reset the bool. 
        canJump = false;
    }

    public void HandleJump(Rigidbody2D player)
    {   
        // Accept a rigid body sprite to add jumping force. 
        if (canJump)
        {   
            // Apply an upwards force, with a slight dragging force to the left. 
            Vector2 forceJump = (Vector2.up) * DataManager.I.GetJumpForce();
            Vector2 leftForce = (Vector2.left) * DataManager.I.GetJumpDrag();
            //player.AddRelativeForce(forceJump); // Do NOT use relative, it works best with normal force, so physics play out naturally. 
            //player.AddRelativeForce(leftForce);
            player.AddForce(forceJump);
            player.AddForce(leftForce);     
        }     
    }
}
