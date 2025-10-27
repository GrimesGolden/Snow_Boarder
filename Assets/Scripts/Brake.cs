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

    public void HandleBrake(SurfaceEffector2D surface)
    {
        if (canBrake)
        {
            float brakeSpeed = DataManager.I.GetBrakeForce();
            surface.speed = brakeSpeed; 
        }
    }
}
