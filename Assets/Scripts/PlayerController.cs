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
    Jump jumpScript;
    Brake brakeScript; 
    // Values to be loaded from data manager
    float torqueAmount;  
    float boostSpeed; 

    float brakeSpeed;  
    float baseSpeed; 

    Animator animator; 
    [SerializeField] SurfaceEffector2D surfaceEffector2D; 

    bool canMove = true; 

    void Start()
    {
        LoadData(); // Load from DataManager
        surfaceEffector2D.speed = baseSpeed; // Standard speed activates. 
        // Add an exclusion layer for Ducky. 
        Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("Player"),
            LayerMask.NameToLayer("Exclude"),
        true);
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
        jumpScript = GetComponent<Jump>(); // Controlling script for jump gameplay.  
        brakeScript = GetComponent<Brake>(); 
        boostScript = GetComponent<Boost>(); // Used for Boost gameplay scripting. 
        rb2d = GetComponent<Rigidbody2D>(); // Used for torque control
        //surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); // Used for speed control. // There may be multiple surface effecots. Serialize.
        GameObject gameManager = GameObject.Find("GameManager"); // Used to access dataManager
        dataManager = DataManager.I; // Used to load data. 

        torqueAmount = dataManager.GetTorqueVal(); // 1f is a good standard. 
        boostSpeed = dataManager.GetBoostSpeed(); // 50 is a good standard.  
        baseSpeed = dataManager.GetBaseSpeed(); // 10-25 is a good standard.

        animator = GetComponentInChildren<Animator>(); // Used for sprite aninations. 
    }

    public void DisableControls()
    {
        // This is why public methods are useful. We need to tell this script to stop working from another script
        // i.e stop the control script FROM a crash detection script. 
        canMove = false;
    }
    
    public void EnableControls()
    {
        canMove = true; 
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
            brakeScript.HandleBrake(rb2d); 
        }
        else if (Input.GetKey(KeyCode.Space))
        // Testing a jump ability. 
        {
            jumpScript.HandleJump(rb2d);
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
