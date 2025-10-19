using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    // A central holding space for importing serialized data and settings
    public static DataManager I { get; private set; } // Only one instance exists per scene. 
    //[SerializeField] Image[] hearts; // The image to represent lives. 
    const int MaxLives = 3; 
    [SerializeField] int lives; // The max amount of lives available. 
    [SerializeField] float crashDelay = 0.5f; // 0.5f is a good standard. // The time to wait before reloading scene after crash. 
    [SerializeField] float torqueAmount = 1f; // 1f is a good standard. // How fast Ducky rotates.
    [SerializeField] float boostSpeed = 450f; // 50 is a good standard.  // How fast Ducky boosts. 
     [SerializeField] float boostDelay = 0.2f; // Debuff speed before boost triggers. (How fast boost will deplete)

    [SerializeField] float brakeSpeed = 5f; // 5 is a good standard. // How hard Ducky brakes. 
    [SerializeField] float baseSpeed = 25f; // 10-25 is a good standard. // Duckys base speed. 

    [SerializeField] int appleValue = 1; // How many scoring points an apple is worth

    [SerializeField] int coffeeAmount = 25; // How much boost value a coffee is worth

    [SerializeField] float appleDelay = 0.5f; // How long an apple pickup should hold before destruction after pickup

    [SerializeField] float coffeeDelay = 0.5f; // How long a coffee pickup should hold before destruction after pickup

    void Awake()
    {
        // This code maintains it so that only one DataManager exists at any one time. 
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject); // Keep the old manager and don't delete the old one

        // Initialize once per app run (could also load from PlayerPrefs here)
        lives = MaxLives;
    }
    
    public void DestroyMe()
    {
        Destroy(DataManager.I.gameObject);
        DataManager.I = null;
    }

    public void TakeDamage()
    {
        lives--;
        ReloadScene();
    }
    public void ReloadScene()
    {
        if (lives <= 0)
        {
            // Explicitely destroy. 
            Destroy(LevelManager.I.gameObject);
            DataManager.I = null;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public int GetLives()
    {
        return lives; 
    }

    public float GetCrashDelay()
    {
        return crashDelay; 
    }

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
