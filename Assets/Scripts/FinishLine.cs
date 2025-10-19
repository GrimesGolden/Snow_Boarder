using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Controller for the FinishLine prefab object. 
    float finishDelay;
    [SerializeField] ParticleSystem finishEffect;
    bool finish = false; 

    void Start()
    {
        LoadData(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !finish)
        {   
            // Stop all previous sounds. 
            // Then play the finish sound and particle effect. 
            SoundManager.StopSound();
            SoundManager.PlaySound(SoundType.FINISH);
            // Play finish particle effect.
            finishEffect.Play();
            // Reset bool to prevent re-trigger. 
            finish = true;
            // Disable controls and evoke a reload. 
            other.GetComponent<PlayerController>().DisableControls(); 
            Invoke("ReloadScene", finishDelay);
        }
    }

    void ReloadScene()
    {
        DataManager.I.DestroyMe(); // Destroy the DM so that we refresh with a new data set. 
        SceneManager.LoadScene(0); // Reload from main menu fresh. 
    }
    
    void LoadData()
    {
        finishDelay = DataManager.I.GetFinishDelay(); 
    }
}
