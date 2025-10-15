using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{

    // A script to handle some camera effects. 

    // A variable representing the camera.
    CinemachineVirtualCamera vcam;
    //[SerializeField] AudioClip slideSFX; 
    float t;

    float standardCam = 10f;
    bool air = false;
    bool air_1 = false;  
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
            if(!air)
            {
                SoundManager.PlaySound(SoundType.AIR);
                air = true; 
                // Set a air bool so the clip doesn't constantly play while in air. 
            }
        }
        else if (t >= 3)
        {
            vcam.m_Lens.OrthographicSize = 20f;
            if(!air_1)
            {
                SoundManager.PlaySound(SoundType.AIR);
                air_1 = true; 
            }
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
        air = false;
        air_1 = false; // reset air timers; 
        vcam.m_Lens.OrthographicSize = standardCam;
        GetComponent<AudioSource>().Play();
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GetComponent<AudioSource>().Stop(); 
    }
}
