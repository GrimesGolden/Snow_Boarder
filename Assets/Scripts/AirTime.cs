using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AirTime : MonoBehaviour
{

    // A script to handle the cameras zoom effect: zooming out when Player in the air for a long time.  

    CinemachineVirtualCamera vcam;
    
    float t;
    float standardCam = 10f; // The distance the camera will normally stand away from the player. 

    bool inAir = false; // Several bools for tracking air time.
    bool isLongAir = false;
    bool isMediumAir = false; 
     void Start()
    {
        // Upon script start, find the virtual camera, and zero out the timer. 
        vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        t = 0;
    }

    void Update()
    {   
        if(inAir)
        {
            // Only track when in air, this saves us updating every frame for no reason.
            TrackAirTime();
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        ResetAirTime();
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Reset the bool. 
        inAir = true;
        // Update will handle tracking. 
    }

    void TrackAirTime()
    {
        // Some constants for camera values and timing. 
        const int long_air = 5; // The times to wait before zooming out. 
        const int medium_air = 3;

        const float long_cam = 30f; // The distance the camera will zoom. 
        const float medium_cam = 20f;

        // Continuously update time (it only resets upon a collision)
        // Essentially we are tracking how long "ducky" is in the air.
        t += Time.deltaTime;

        // Manage accordingly
        if (t >= long_air && !isLongAir)
        {
            // The longer the time in air, the larger the camera will zoom out, for a cool effect. 
            // It only triggers once. 
            vcam.m_Lens.OrthographicSize = long_cam;
            isLongAir = true;
            inAir = false; // If long air is achieved, there is no reason to track anything else. Act as if we hit the ground.  
        }
        else if (t >= medium_air && !isMediumAir)
        {
            SoundManager.PlaySound(SoundType.AIR); // Play a sound here.
            // Again this only triggers once. 
            vcam.m_Lens.OrthographicSize = medium_cam;
            isMediumAir = true;
        }
    }
    
    public void ResetAirTime()
    {   
        // Zero out the timer, and return to standard camera size. 
        t = 0;
        // Reset boolean triggers (these prevent looping sound)
        inAir = false; 
        isLongAir = false;
        isMediumAir = false;
        // Return to the normal camera upon landing. 
        vcam.m_Lens.OrthographicSize = standardCam;
    }
}
