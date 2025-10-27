using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    // A dirty end credits script.
    // it's full of magic numbers and follows no decent logic. 
    // I hope you enjoyed Ducky's world
    // Jordan Tobin 2025
    float t = 0;
    int sceneIndex;
    bool active = false; 
    [SerializeField] PopupText txt;
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void LevelOne()
    {
        if (t >= 1 && t <= 5)
        {
            txt.Show("Welcome to Ducky's world. Meet Ducky, the snowboarding Duck...");
        }
        else if (t >= 7)
        {
            txt.Show("One Day, Ducky had the world's best snowboarding run.");
            active = true;
        }
    }

    void LevelTwo()
    {
        if (t >= 1 && t <= 5)
        {   // run so perfect, so fast, that the elder gods themselves bore witness
            txt.Show("But the run was too fast, too perfect...");
        }
        else if (t >= 7 && t <= 15)
        {
            txt.Show("The elder gods THEMSELVES bore witness...transporting Ducky to an Eldritch world");
        }
        else if (t >= 15 && t <= 20)
        {
            txt.Show("Help our brave Ducky get back to his world!!!");
        }
    }   

    void LevelThree()
    {
        if (t >= 3 && t <= 5)
        {
            txt.Show("Where am I? Thought Ducky...");
        }
    }
    
    void ShowCredits()
    {
        if (t >= 0 && t <= 5)
        {
            txt.Show("What's that sound, OH! Ducky's home!!! :D");
        }

        else if (t >= 5 && t <= 10)
        {
            txt.Show("All sounds and assets downloaded for free, ripped from youtube, or recorded by friends and family!");
        }

        else if (t >= 11 && t <= 15)
        {
            txt.Show("No Ducks were harmed in the making of this game.");
        }

        else if (t >= 16 && t <= 20)
        {
            txt.Show("Refactoring is overated");
        }
        
        else if (t >= 21 && t <= 30)
        {
            txt.Show("Thanks for playing, I hope you had fun! - Jordan");
        }
    }
    
        void FixedUpdate()
    {   
        t += Time.deltaTime;
        if (sceneIndex == 4)
        {
            ShowCredits();
        }
        else if (sceneIndex == 1 && !active && DataManager.I.GetLives() == 3)
        {
            LevelOne();
        }
        else if (sceneIndex == 2 && !active && DataManager.I.GetLives() == 3)
        {
            LevelTwo();
        }
        else if (sceneIndex == 3 && !active && DataManager.I.GetLives() == 3)
        {   
            // This is very bad code, and I am ashamed. I swear it's not usually like this...
            LevelThree(); 
        }
    }
} 
