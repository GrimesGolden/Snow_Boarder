using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{   
    // Handles collisions including the crashEffect and healthBar. 
    float crashDelay;
    [SerializeField] ParticleSystem crashEffect;

    [SerializeField] GameObject healthBar;
    bool isCrash = false; 
    
    GameObject gameManager;
    DataManager dataManager; 

    void Start()
    {
        LoadData(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain" && !isCrash)
        {
            SoundManager.PlaySound(SoundType.CRASH);
            crashEffect.Play();
            GetComponent<PlayerController>().DisableControls(); // Disable controls to prevent player moving after collision. 
            isCrash = true; // Prevent retrigger. 
            Invoke("UpdateLevel", crashDelay);
        }
    }

    void UpdateLevel()
    {
        dataManager.TakeDamage();
    }
    
    void LoadData()
    {
        gameManager = GameObject.Find("GameManager"); // Find object and scripts for later activation.
        dataManager = gameManager.GetComponent<DataManager>();
        crashDelay = dataManager.GetCrashDelay(); 
        
    }
}
