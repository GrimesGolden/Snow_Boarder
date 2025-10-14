using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 450f;

    [SerializeField] float brakeSpeed = 5f; 
    [SerializeField] float baseSpeed = 25f;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2D.speed = baseSpeed;
    }

    void Update()
    {
        RotatePlayer();
        ControlSpeed(); 
    }

    void ControlSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Debug.Log("Use the boost to get through.");
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = brakeSpeed;
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
