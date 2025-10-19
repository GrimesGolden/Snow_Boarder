using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    // Simple script for the main menu. 
    public void PlayGame()
    {   
        // Loads the next scene on click.
        GetComponent<AudioSource>().Stop(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
