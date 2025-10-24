using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.ShaderGraph.Internal;
using Unity.VisualScripting;

public class DataManager : MonoBehaviour
{
    // A central holding space for importing serialized data and settings
    public static DataManager I { get; private set; } // Only one instance exists per scene. 
    const int MaxLives = 3; 
    [SerializeField] int lives; // The max amount of lives available. 
    [SerializeField] float crashDelay = 0.5f; // 0.5f is a good standard. // The time to wait before reloading scene after crash. 
    [SerializeField] float finishDelay = 1f; // 1f is a good standard. // The time to wait before reloading after finish. 
    [SerializeField] float torqueAmount = 1f; // 1f is a good standard. // How fast Ducky rotates.
    [SerializeField] float boostSpeed = 450f; // 50 is a good standard.  // How fast Ducky boosts. 
    [SerializeField] float boostDelay = 0.2f; // Debuff speed before boost triggers. (How fast boost will deplete)

    [SerializeField] float baseSpeed = 25f; // 10-25 is a good standard. // Duckys base speed. 

    [SerializeField] float jumpForce = 35f; // 35f is a good standard. //Ducky's jump force which determines height. 
    [SerializeField] float jumpDrag = 5f; // 5f is a good standard. //Ducky's jump drag which effects jumping resistance. 
    [SerializeField] float brakeForce = 5f; // 5-10f is a good standard. // Ducky's braking vector force. 

    [SerializeField] int appleValue = 1; // How many scoring points an apple is worth

    [SerializeField] int coffeeAmount = 25; // How much boost value a coffee is worth

    [SerializeField] float appleDelay = 0.5f; // How long an apple pickup should hold before destruction after pickup

    [SerializeField] float coffeeDelay = 0.5f; // How long a coffee pickup should hold before destruction after pickup

    [SerializeField] int long_air = 5; // The time to wait before zooming out the ortho camera. 
    [SerializeField] int medium_air = 3; // The time to wait before zooming out the ortho camera.

    [SerializeField] float base_cam = 10f; // The standard camera distance. 
    [SerializeField] float medium_cam = 20f; // The distance the camera will zoom out after medium wait. 
    [SerializeField] float long_cam = 30f; // The distance the camera will zoom out. 
     [SerializeField] float slimeDelay = 1f; // 1f is a good standard. // Time to wait for processing of slime death animations. 
    [SerializeField] float slimeBounce = 500f; //500f is a good amount // The force a slime enemy delivers upon death.

    [SerializeField] float slimeJump = 350f; // 350f is good // The force a Jumpy variant of slime jumps with.

    [SerializeField] float slimeRefresh = 0.5f; // 0.5f is good  // The delay before next update of a moving slime

    [SerializeField] float slimeMove = 350f; // Between 250 and 500 is good // The force with which a slime moves. 

    [SerializeField] float slimeDrag = 5f; // Unknown // The drag jump on a moving slime.

    [SerializeField] float platformRate = 0.1f; // The vertical speed of moving platforms. // 0.1 f is decent. 

    [SerializeField] float platformHeight = 10f; // The max height of a floating platform. // 10f is decent.  

    void Awake()
    {
        // This code maintains it so that only one DataManager exists at any one time. 
        // A persistent slot across memory where I refers to a static DataManager that is in the DontDestroyOnLoad pocket. i.e persistant + static. 
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
            Destroy(DataManager.I.gameObject);
            DataManager.I = null;
            SceneManager.LoadScene(0);
        }
        else
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(sceneIndex);
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
    
    public float GetFinishDelay()
    {
        return finishDelay; 
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

    public float GetSlimeDelay()
    {
        return slimeDelay;
    }
    
    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public float GetJumpForce()
    {
        return jumpForce;
    }

    public float GetJumpDrag()
    {
        return jumpDrag;
    }
    
    public float GetBrakeForce()
    {
        return brakeForce; 
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

    public int GetLongAir()
    {
        return long_air;
    }

    public int GetMedAir()
    {
        return medium_air;
    }

    public float GetBaseCam()
    {
        return base_cam;
    }

    public float GetMedCam()
    {
        return medium_cam;
    }

    public float GetLongCam()
    {
        return long_cam;
    }

    public float GetSlimeBounce()
    {
        return slimeBounce;
    }

    public float GetSlimeJump()
    {
        return slimeJump;
    }

    public float GetSlimeRefresh()
    {
        return slimeRefresh;
    }

    public float GetSlimeMove()
    {
        return slimeMove;
    }

    public float GetSlimeDrag()
    {
        return slimeDrag;
    }

    public float GetPlatformRate()
    {
        return platformRate;
    }
    
    public float GetPlatformHeight()
    {
        return platformHeight;  
    }
}
