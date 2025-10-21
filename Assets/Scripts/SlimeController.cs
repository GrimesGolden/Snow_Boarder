using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    CrashDetector crashDetector;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Board")
        {
            crashDetector = other.gameObject.GetComponent<CrashDetector>();
            crashDetector.ExplodeDucky(); 
        }
    }
}
