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
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        SoundManager.StopSound();
    }

    void StopGame()
    {
        Time.timeScale = 0f;
        SoundManager.StopSound();
        player.GetComponent<DustTrail>().StopTrailSound();
        SoundManager.PlaySound(SoundType.PAUSE);
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }
}
