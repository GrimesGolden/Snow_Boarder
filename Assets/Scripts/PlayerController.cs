using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    DataManager dataManager; 
    float torqueAmount; // 1f is a good standard. 
    float boostSpeed; // 50 is a good standard.  

    float brakeSpeed; // 5 is a good standard. 
    float baseSpeed; // 10-25 is a good standard.

    [SerializeField] Animator animator; 
    SurfaceEffector2D surfaceEffector2D; 

    bool canMove = true; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Used for torque control
        LoadData(); 
        
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); // Used for speed control. 
        surfaceEffector2D.speed = baseSpeed;
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
        GameObject gameManager = GameObject.Find("GameManager");
        dataManager = gameManager.GetComponentInChildren<DataManager>();

        torqueAmount = dataManager.GetTorqueVal(); // 1f is a good standard. 
        boostSpeed = dataManager.GetBoostSpeed(); // 50 is a good standard.  

        brakeSpeed = dataManager.GetBrakeSpeed(); // 5 is a good standard. 
        baseSpeed = dataManager.GetBaseSpeed(); // 10-25 is a good standard.
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
            Debug.Log("Up arrow detected.");
            GetComponent<Boost>().HandleBoost(surfaceEffector2D, boostSpeed, baseSpeed);
            animator.SetFloat("Speed", boostSpeed); 
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = brakeSpeed;
            animator.SetFloat("Speed", brakeSpeed);
            // Access the public reset method of camera controller and reset it here.
            // This prevents slide time during braking, behaving as air time. 
            GetComponent<AirTime>().ResetAirTime(); 
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed; 
            animator.SetFloat("Speed", baseSpeed);
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
