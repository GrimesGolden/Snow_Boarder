using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    int count = 0; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {   
            ++count;
            Debug.Log("Hitted on head " + count + " times!"); 
        }
    }
}
