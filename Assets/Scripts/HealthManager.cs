using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Manage the health bar (deleting icons as lives deplete)
    [SerializeField] Image[] hearts;

    int lives;

    void Start()
    {
        //gameManager = GameObject.Find("GameManager");
       // dataManager = gameManager.GetComponent<DataManager>();

        lives = DataManager.I.GetLives(); 
        RefreshHearts(); 
    }

    void RefreshHearts()
    {
        for (int i = (hearts.Length); i > lives; --i)
        // Iterate backwards through the hearts image array.
        // Deactivate in accordance with remaining lives. 
        {
            hearts[i - 1].gameObject.SetActive(false);
        }
    }
}

