using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtTrigger : MonoBehaviour
{
    // A popup for the end of the game. 
    [SerializeField] PopupText txt;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            txt.Show("Quickly Ducky! Into the portal!...the wizard left this open."); 
        }
    }
}
