using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    DataManager dataManager;

    Boost boostScript; 
    // Values to be loaded from data manager
    float torqueAmount;  
    float boostSpeed; 

    float brakeSpeed;  
    float baseSpeed; 

    Animator animator; 
    SurfaceEffector2D surfaceEffector2D; 

    bool canMove = true; 

    void Start()
    {
        LoadData(); // Load from DataManager
        surfaceEffector2D.speed = baseSpeed; // Standard speed activates. 
    }

    void Update()
    {
        //Lock the controls. 
        if (canMove)
        {
            RotatePlayer();
            ControlSpeed();
        }
    }
    
    void LoadData()
    {
        boostScript = GetComponent<Boost>(); // Used for Boost gameplay scripting. 
        rb2d = GetComponent<Rigidbody2D>(); // Used for torque control
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); // Used for speed control.
        GameObject gameManager = GameObject.Find("GameManager"); // Used to access dataManager
        dataManager = gameManager.GetComponentInChildren<DataManager>(); // Used to load data. 

        torqueAmount = dataManager.GetTorqueVal(); // 1f is a good standard. 
        boostSpeed = dataManager.GetBoostSpeed(); // 50 is a good standard.  

        brakeSpeed = dataManager.GetBrakeSpeed(); // 5 is a good standard. 
        baseSpeed = dataManager.GetBaseSpeed(); // 10-25 is a good standard.

        animator = GetComponentInChildren<Animator>(); // Used for sprite aninations. 
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
            // Activate boost effects. 
            boostScript.HandleBoost(surfaceEffector2D, boostSpeed, baseSpeed); 
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {   
            // Adjust speed and animation. 
            surfaceEffector2D.speed = brakeSpeed;
            animator.SetFloat("Speed", brakeSpeed);
            // Access the public reset method of camera controller and reset it here.
            // This prevents slide time during braking, behaving as air time. 
            GetComponent<AirTime>().ResetAirTime(); 
        }
        else
        {   
            // Speed continues as usual. 
            animator.SetFloat("Speed", baseSpeed);
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
