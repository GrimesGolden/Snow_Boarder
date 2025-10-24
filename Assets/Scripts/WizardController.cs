using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    float t = 5;
    float hurtTimer = 5;
    int health = 3;

    bool isAwake = false; 
    bool isHurt = false; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("playerDetected", true);
            isAwake = true; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("playerDetected", false);
            isAwake = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        if(hurtTimer >= 5) // hurtwait
        {
            Hurt();
            hurtTimer = 0; 
        } 
    }

    void Dash()
    {
        //gameObject.GetComponent<Animator>().SetBool("isDash", true);
        //Vector2 oldPos = gameObject.transform.position;
        //oldPos.x += 5;
        //gameObject.transform.position = oldPos;
        gameObject.GetComponent<Animator>().SetBool("isDash", true); // dash animation
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject player = players[0];
        Vector2 playerPos = player.transform.position;
        Vector2 wizPos = gameObject.transform.position;
        wizPos.x = playerPos.x + 5;
        wizPos.y = playerPos.y + 3;
        gameObject.transform.position = wizPos; 
    }

    void Hurt()
    {
        gameObject.GetComponent<Animator>().SetBool("wizardHurt", true);
        health--;

        gameObject.GetComponent<SpriteRenderer>().color = Color.red;  // CHANGE COLOR.

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Animator>().SetBool("isDash", false);
    }
    
    void FixedUpdate()
     {

        if(isAwake && t >= 1)
        {   
            t = 0;
            Dash();
            gameObject.GetComponent<Animator>().SetBool("isDash", false);  
        }

        // t = 0;
        t += Time.fixedDeltaTime;
        hurtTimer += Time.fixedDeltaTime;

        if(hurtTimer >= 5)
        {
             gameObject.GetComponent<SpriteRenderer>().color = Color.white;  // CHANGE COLOR back to standard after 5. 
        } 
       // if (t >= 5)
      //  {
      //      Dash();
     //       gameObject.GetComponent<Animator>().SetBool("isDash", false);
       //     t = 0;
    //    }

    }
}
