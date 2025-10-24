using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    GameObject player;
    float t = 0;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<CrashDetector>().ExplodeDucky();
        }
    }
    
    void FixedUpdate()
    {
        t += Time.deltaTime; 
        Vector2 pos = transform.position;
        pos.x -= 0.05f;
        transform.position = pos; 
        if(t >= 30f)
        {
            Destroy(gameObject); // Bullets last 30 seconds before destruction. 
        }
    }
}
