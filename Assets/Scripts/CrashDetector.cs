using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    [SerializeField] GameObject healthBar;
    bool isCrash = false; 
    
    GameObject gameManager;
    LevelManager manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain" && !isCrash)
        {
            SoundManager.PlaySound(SoundType.CRASH);
            crashEffect.Play();
            GetComponent<PlayerController>().DisableControls();
            isCrash = true;
            //gameManager = GameObject.Find("GameManager"); // Find and activate script. 
            //manager = gameManager.GetComponent<Manager>(); 
            //manager.TakeDamage();
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        gameManager = GameObject.Find("GameManager"); // Find and activate script. 
        manager = gameManager.GetComponent<LevelManager>(); 
        manager.TakeDamage();
    }
}
