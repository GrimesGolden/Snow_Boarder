using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    bool canBrake = false;
     void OnCollisionEnter2D(Collision2D other)
    {
        canBrake = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Reset the bool. 
        canBrake = false;
        // Update will handle tracking. 
    }

    public void HandleBrake(Rigidbody2D player)
    {
        if (canBrake)
        {
            Vector2 forceJump = (Vector2.left) * DataManager.I.GetBrakeForce();
            player.AddForce(forceJump);
        }
    }
}
