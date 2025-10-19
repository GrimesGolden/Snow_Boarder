using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Handles pause menu and pause functionality. 
    bool GameIsPaused = false;

    GameObject pauseMenuUI;
    GameObject player; 
    
    void Start()
    {
        pauseMenuUI = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
        player = GameObject.Find("Ducky"); // Search through the entire hierarchy for ducky. 
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
        pauseMenuUI.SetActive(false); // Hide pause menu
        SoundManager.StopSound(); // Stop the pause menu song. 
    }

    void StopGame()
    {
        Time.timeScale = 0f; // Pause the game literally, stop the time scale. 
        SoundManager.StopSound(); // Stop all sounds currently playing. 
        player.GetComponent<DustTrail>().StopTrailSound();

        SoundManager.PlaySound(SoundType.PAUSE); // Play pause menu jingle and show UI. 
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }
}
