using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoostCounter : MonoBehaviour
{   
    //Q: Why have the boost be managed seperately from the Player GameObject, within its own GameObject?
    // A: A couple of reasons, but the main one is that if the Player object tracks the boost, then we pass this variable around to at least 3 different scripts:
    // The player object, the counter, and the boost effect script. Having it in this object lets the text and updating count itself.
    // Its much easier this way.

    // This script handles the boost text, and keeps track of our total boost amount.

    private int boostCount = 0; // We start with zero boost. 

    TextMeshProUGUI uiText;
    void Start()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>(); // Access the child text object. 
    }

    void UpdateCounter()
    {   
        // Update the UI text component.
        uiText.text = "BOOST: " + boostCount.ToString("#,0");
    }

    public int GetBoostCount()
    {
        return boostCount;
    }

    public void AddBoostCount(int boostVal)
    {   
        // Increase the boost count (for example from a pickup)
        boostCount += boostVal;
        UpdateCounter();
    }

    public void SubBoostCount(int boostVal)
    {   
        // Decrease when the boost is used
        boostCount -= boostVal;
        UpdateCounter(); 
    }
}
