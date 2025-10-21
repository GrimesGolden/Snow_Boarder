using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{   
    // Handles collisions including the crashEffect and healthBar. 
    float crashDelay;
    [SerializeField] ParticleSystem crashEffect;
    Animator duckyAnimator; 

    bool isCrash = false; 
    
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
        DataManager.I.TakeDamage();
    }

    void LoadData()
    {
        // gameManager = GameObject.Find("GameManager"); // Find object and scripts for later activation.
        // dataManager = gameManager.GetComponent<DataManager>();
        crashDelay = DataManager.I.GetCrashDelay();
        duckyAnimator = gameObject.GetComponent<Animator>();

    }
    
    public void ExplodeDucky()
    {
        // Similar to a crash, but this specifically causes Ducky to dramatically explode.
        // Useful for enemies and other obstacles.
        SoundManager.PlaySound(SoundType.CRASH); // This will eventually be an explode sound.
        GameObject board = GameObject.Find("Snowboard");
        Destroy(board);
        duckyAnimator.SetBool("IsExplode", true);
        GetComponent<PlayerController>().DisableControls();
        Invoke("UpdateLevel", crashDelay);
    }
}
