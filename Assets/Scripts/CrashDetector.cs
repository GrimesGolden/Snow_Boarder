using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    bool isCrash = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain" && !isCrash)
        {
            SoundManager.PlaySound(SoundType.CRASH); // Use the sound manager to play appropriate sound. 
            // This is the particle effect. 
            crashEffect.Play();
            // Disable the controls. 
            GetComponent<PlayerController>().DisableControls();
            // Reset bool trigger (preventing re-trigger)
            isCrash = true; 
            // Reload the level. 
            Invoke("ReloadScene", loadDelay); 
        }
    }

    void ReloadScene()
    {   
        // Note that scene manager must be imported. 
        SceneManager.LoadScene(0);
    }
}
