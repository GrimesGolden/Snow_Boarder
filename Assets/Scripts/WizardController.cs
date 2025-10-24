using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("playerDetected", true); 
        }
    }
}
