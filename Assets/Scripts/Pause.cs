using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Handles pause menu and pause functionality. 
    bool GameIsPaused = false;
    TextMeshProUGUI pauseText; 
    GameObject player; 
    
    void Start()
    {
        pauseText = GetComponentInChildren<TextMeshProUGUI>(true);  // Get the pause text. // The true argument says to search even inactive objects. 
        player = GameObject.Find("Ducky"); // Search through the entire hierarchy for ducky. 
        pauseText.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (!GameIsPaused)
            {
                StopGame();
            }

        }
    }

    void Resume()
    {
        Time.timeScale = 1f; // Set the time scale back to normal (game no longer paused)
        GameIsPaused = false;
        pauseText.enabled = false;  // Hide pause text. 
        SoundManager.StopSound(); // Stop the pause menu song. 
    }

    void StopGame()
    {
        Time.timeScale = 0f; // Pause the game literally, stop the time scale. 
        SoundManager.StopSound(); // Stop all sounds currently playing. 
        player.GetComponent<DustTrail>().StopTrailSound();

        SoundManager.PlaySound(SoundType.PAUSE); // Play pause menu jingle and show UI. 
        GameIsPaused = true;
        pauseText.enabled = true; // Show pause text. 
    }
}
