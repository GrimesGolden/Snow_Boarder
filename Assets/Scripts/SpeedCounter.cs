using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedCounter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    public float speed = 0f;

    [SerializeField] Rigidbody2D player;

    void Start()
    {
        // Access the text component (on this or child object)
        uiText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        // Get the Rigidbody2D's velocity vector
        Vector2 velocity = player.velocity;

        // Calculate the magnitude (overall speed, independent of direction)
        speed = velocity.magnitude;

        // Display it
        uiText.text = "Speed: " + speed.ToString("F1") + "mph";
    }
}
