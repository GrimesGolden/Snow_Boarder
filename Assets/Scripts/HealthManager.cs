using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    GameObject gameManager;
    Manager manager;
    public Image[] hearts;

    int health;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<Manager>();
        Debug.Log("Here we are and health is " + manager.Health);


        // Refresh hearts.
      //  Debug.Log("Refreshing hearts.");
       // Debug.Log("i outside" + hearts.Length); 
        for (int i = (hearts.Length); i > manager.Health; --i)
        {
            //Debug.Log("Refreshing hearts.");
           // Debug.Log("i inside: " + i);
            hearts[i-1].gameObject.SetActive(false);
        }
    }
    // void Update()
    //  {


    // }

    //public void RefreshHearts()
    //   {
    //   for (int i = (hearts.Length) - 1; i > manager.Health; --i)
    //   {
    //       hearts[i].gameObject.SetActive(false);
    //  }
    //SceneManager.LoadScene(1); // Now this class is managing health and maybe it should somehow exist outside of this health bar. 
    // Much REFACTORING TO DO. 
}

