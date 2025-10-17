using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AirTime : MonoBehaviour
{

    // A script to handle the cameras zoom effect, zooming out when in the air for a long time.  

       CinemachineVirtualCamera vcam;
    //[SerializeField] AudioClip slideSFX; 
    float t;

    float standardCam = 10f;
    bool isLongAir = false;
    //bool isMediumAir = false;  
     void Start()
    {
        // Upon script start, find the virtual camera, and zero out the timer. 
        vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        t = 0;
    }

    void Update()
    {
        TrackAirTime(); 
    }
    
    void TrackAirTime()
    {   
        // Some constants for camera values and timing. 
        const int long_air = 5;
        const int medium_air = 3;
       // const int short_air = 2;

        const float long_cam = 30f;
        const float medium_cam = 20f;
        //const float short_cam = 15f;  

        // Continuously update time (it only resets upon a collision)
        // Essentially we are tracking how long "ducky" is in the air.
        t += Time.deltaTime;

        // Manage accordingly
        if (t >= long_air)
        {
            // The longer the time in air, the larger the camera will zoom out, for a cool effect. 
            vcam.m_Lens.OrthographicSize = long_cam; 

            if(!isLongAir)
            {
                SoundManager.PlaySound(SoundType.AIR);
                isLongAir = true; 
                // Set a air bool so the clip doesn't constantly play while in air. 
            }
        }
        else if (t >= medium_air)
        {
            vcam.m_Lens.OrthographicSize = medium_cam;

           // if(!isMediumAir)
          //  {
             // /  SoundManager.PlaySound(SoundType.AIR);
             //   isMediumAir = true; 
          //  }
        }
       // else if (t >= short_air)
        //{
       //     vcam.m_Lens.OrthographicSize = short_cam;
       // }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ResetAirTime(); 
    }

    public void ResetAirTime()
    {   
        // Zero out the timer, and return to standard camera size. 
        t = 0;
        // Reset boolean triggers (these prevent looping sound)
        isLongAir = false;
        //isMediumAir = false;
        // Return to the normal camera upon landing. 
        vcam.m_Lens.OrthographicSize = standardCam;

    }
}
