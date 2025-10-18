using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    GameObject gameManager;
    LevelManager manager;
    [SerializeField] Image[] hearts;

    int health;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<LevelManager>();

        for (int i = (hearts.Length); i > manager.Health; --i)
        {
            hearts[i - 1].gameObject.SetActive(false);
        }
    }
}

