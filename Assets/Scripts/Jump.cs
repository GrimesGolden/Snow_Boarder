using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    bool canJump = false;
     void OnCollisionEnter2D(Collision2D other)
    {
        canJump = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Reset the bool. 
        canJump = false;
        // Update will handle tracking. 
    }

    public void HandleJump(Rigidbody2D player)
    {
        if (canJump)
        {
            Vector2 forceJump = (Vector2.up) * DataManager.I.GetJumpForce();
            player.AddForce(forceJump);
        }
    }
}
