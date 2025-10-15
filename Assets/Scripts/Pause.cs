using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool GameIsPaused = false;
    [SerializeField] GameObject pauseMenuUI; 
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
        GetComponent<DustTrail>().StopTrailSound(); 
        SoundManager.PlaySound(SoundType.PAUSE); 
        GameIsPaused = true;
        pauseMenuUI.SetActive(true); 
    }
}
