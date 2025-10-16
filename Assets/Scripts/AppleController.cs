using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    [SerializeField] ParticleSystem appleEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            SoundManager.PlaySound(SoundType.APPLE);
            appleEffect.Play();
            Invoke("DestroyApple", 0.5f); 
      
        }
    }
    
    void DestroyApple()
    {
        Destroy(gameObject); 
    }
}
