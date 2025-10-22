//using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    CrashDetector crashDetector;
    Vector3 slimePos;

    Rigidbody2D slimeBod;

    float t = 1; 

    void Start()
    {
        slimePos = transform.position;
        slimeBod = gameObject.GetComponent<Rigidbody2D>(); 

    }

    void Update()
    {
        t += Time.deltaTime;
       // Debug.Log(t);
        if (gameObject.tag == "Jumpy" && t >= 1)
        {
            Jump();
            t = 0;
        }
        else if (gameObject.tag == "Slimy")
        {
            Attack();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Board")
        {
            gameObject.GetComponent<Animator>().SetBool("SlimeDead", true);
            // use the crash detector to trigger an explosion varient of crash. 
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50);
            crashDetector = other.gameObject.GetComponent<CrashDetector>();
            crashDetector.ExplodeDucky();
        }
    }
    
    void Jump()
    {
        Vector2 jumpForce = Vector2.up * 350;
        slimeBod.AddRelativeForce(jumpForce);
    }

    void Attack()
    {
        //Vector2 downForce = Vector2.down * 5;
        Vector2 brakeForce = Vector2.left * 2;
        //slimeBod.AddForce(downForce);
        //slimeBod.AddForce(brakeForce);
        slimeBod.AddRelativeForce(brakeForce);
    }

    public void DestroySlime()
    {
        gameObject.GetComponent<Animator>().SetBool("SlimeDead", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("ByeSlime", 1);
        Debug.Log("Slime DESTROYED!");
    }
    
    void ByeSlime()
    {
        Destroy(gameObject);
    }
    

    
}
