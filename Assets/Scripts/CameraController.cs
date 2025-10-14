using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{

    // A script to handle some camera effects. 

    // A variable representing the camera.
    CinemachineVirtualCamera vcam;

    // A float to track elapsed time. 
    float t;

    float standardCam = 10f; 
     void Start()
    {
        // Upon script start, find the virtual camera, and zero out the timer. 
        vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        t = 0;
    }

    void Update()
    {
        // Continuously update time (it only resets upon a collision)
        t += Time.deltaTime;

        // A lot of magic numbers here, I know. 
        if (t >= 5)
        {   
            // The longer the time in air, the larger the camera will zoom out, for a cool effect. 
            vcam.m_Lens.OrthographicSize = 30f;
        }
        else if (t >= 3)
        {
            vcam.m_Lens.OrthographicSize = 20f;
        }
        else if (t >= 2)
        {
            vcam.m_Lens.OrthographicSize = 15f;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {   
        // Zero out the timer, and return to standard camera size. 
        t = 0;
        vcam.m_Lens.OrthographicSize = standardCam; 
    }

   // void OnCollisionExit2D(Collision2D other)
   // {
    //}
}
