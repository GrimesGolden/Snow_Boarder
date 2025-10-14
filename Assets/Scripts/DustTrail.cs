using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        snowEffect.Play();
    }
    
    void OnCollisionExit2D(Collision2D other) {
        snowEffect.Stop(); 
    }
}
