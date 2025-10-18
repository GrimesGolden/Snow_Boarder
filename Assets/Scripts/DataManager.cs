using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // A central holding space for importing serialized data and settings
    [SerializeField] float torqueAmount = 1f; // 1f is a good standard. // How fast Ducky rotates.
    [SerializeField] float boostSpeed = 450f; // 50 is a good standard.  // How fast Ducky boosts. 
     [SerializeField] float boostDelay = 0.2f; // Debuff speed before boost triggers. (How fast boost will deplete)

    [SerializeField] float brakeSpeed = 5f; // 5 is a good standard. // How hard Ducky brakes. 
    [SerializeField] float baseSpeed = 25f; // 10-25 is a good standard. // Duckys base speed. 

    [SerializeField] int appleValue = 1; // How many scoring points an apple is worth

    [SerializeField] int coffeeAmount = 25; // How much boost value a coffee is worth

    [SerializeField] float appleDelay = 0.5f; // How long an apple pickup should hold before destruction after pickup

    [SerializeField] float coffeeDelay = 0.5f; // How long a coffee pickup should hold before destruction after pickup

    public float GetTorqueVal()
    {
        return torqueAmount;
    }

    public float GetBoostSpeed()
    {
        return boostSpeed;
    }

    public float GetBoostDelay()
    {
        return boostDelay; 
    }

    public float GetBrakeSpeed()
    {
        return brakeSpeed;
    }

    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public int GetCoffeeVal()
    {
        return coffeeAmount;
    }

    public float GetCoffeeDelay()
    {
        return coffeeDelay;
    }

    public int GetAppleVal()
    {
        return appleValue;
    }
    
    public float GetAppleDelay()
    {
        return appleDelay; 
    }
}
