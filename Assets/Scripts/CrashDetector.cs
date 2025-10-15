using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            Invoke("ReloadScene", loadDelay); 
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
