using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f; // 1f is a good standard. 
    [SerializeField] float boostSpeed = 450f; // 50 is a good standard.  

    [SerializeField] float brakeSpeed = 5f; // 5 is a good standard. 
    [SerializeField] float baseSpeed = 25f; // 10-25 is a good standard.
    SurfaceEffector2D surfaceEffector2D; 

    bool canMove = true; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Used for torque control
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); // Used for speed control. 
        surfaceEffector2D.speed = baseSpeed;
    }

    void Update()
    {   
        //Lock the controls. 
        if(canMove)
        {
            RotatePlayer();
            ControlSpeed();
        }
    }

    public void DisableControls()
    {   
        // This is why public methods are useful. We need to tell this script to stop working from another script
        // i.e stop the control script FROM a crash detection script. 
        canMove = false; 
    }

    void ControlSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = brakeSpeed;
            // Access the public reset method of camera controller and reset it here.
            // This prevents slide time during braking, behaving as air time. 
            GetComponent<AirTime>().ResetAirTime(); 
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed; 
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount); 
        }
    }
}
