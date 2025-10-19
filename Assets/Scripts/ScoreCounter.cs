using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    public int score = 0;
    void Start()
    {   
        ///Find a way to access this component, a component of the child object. 
        uiText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "SCORE: " + score.ToString("#,0");
    }

    public void UpdateScore()
    {
        uiText.text = "SCORE: " + score.ToString("#,0");
    }
}
