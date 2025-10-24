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

    PlayerController playerController; 
    
    void Start()
    {
        pauseText = GetComponentInChildren<TextMeshProUGUI>(true);  // Get the pause text. 
        // // The true argument says to search even inactive objects. 
        player = GameObject.FindWithTag("Player");; // Search through the entire hierarchy for ducky. 
        playerController = player.GetComponent<PlayerController>(); // Use this to disable controls. 
        pauseText.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                playerController.EnableControls();
                Resume();
            }
            else if (!GameIsPaused)
            {
                StopGame();
                playerController.DisableControls(); 
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
