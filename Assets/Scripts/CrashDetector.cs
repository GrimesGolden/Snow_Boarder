using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {
            SoundManager.PlaySound(SoundType.CRASH); // Use the sound manager to play appropriate sound. 
            crashEffect.Play();
            Invoke("ReloadScene", loadDelay); 
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
