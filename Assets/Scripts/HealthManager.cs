using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    GameObject gameManager;
    DataManager dataManager;
    [SerializeField] Image[] hearts;

    int lives;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        dataManager = gameManager.GetComponent<DataManager>();

        lives = dataManager.GetLives(); 
        RefreshHearts(); 
    }

    void RefreshHearts()
    {
        for (int i = (hearts.Length); i > lives; --i)
        {
            hearts[i - 1].gameObject.SetActive(false);
        }
    }
}

