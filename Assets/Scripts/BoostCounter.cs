using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoostCounter : MonoBehaviour
{
    //private TextMeshProUGUI uiText;
    private int boostCount = 0; // We start with zero boost. 

    TextMeshProUGUI uiText;
    void Start()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>(); // Access the child text object. 
    }

    void UpdateCounter()
    {
        uiText.text = "BOOST: " + boostCount.ToString("#,0");
    }

    public int GetBoostCount()
    {
        return boostCount;
    }

    public void AddBoostCount(int boostVal)
    {
        boostCount += boostVal;
        UpdateCounter();
    }

    public void SubBoostCount(int boostVal)
    {
        boostCount -= boostVal;
        UpdateCounter(); 
    }
}
