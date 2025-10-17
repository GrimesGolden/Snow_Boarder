using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoostCounter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    public int boostVal = 10000; 
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "BOOST: " + boostVal.ToString("#,0");
    }
}
