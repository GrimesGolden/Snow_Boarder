using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    GameObject player; 
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<CrashDetector>().ExplodeDucky(); 
        }
    }
}
