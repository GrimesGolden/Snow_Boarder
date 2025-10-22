//using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.VisualScripting;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    CrashDetector crashDetector;
    Vector3 slimePos;

    Rigidbody2D slimeBod; 

    void Start()
    {
        slimePos = transform.position;
        slimeBod = gameObject.GetComponent<Rigidbody2D>(); 

    }
    
    void Update()
    {
        //Vector2 downForce = Vector2.down * 5;
        Vector2 brakeForce = Vector2.left * 2;
        //slimeBod.AddForce(downForce);
        //slimeBod.AddForce(brakeForce);
        slimeBod.AddRelativeForce(brakeForce);
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
    

    
}
