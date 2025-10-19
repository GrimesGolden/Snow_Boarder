using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float finishDelay;
    [SerializeField] ParticleSystem finishEffect;

    DataManager dataManager;

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
            finishEffect.Play();
            // Reset bool to prevent re-trigger. 
            finish = true;
            other.GetComponent<PlayerController>().DisableControls(); 
            Invoke("ReloadScene", finishDelay);
        }
    }

    void ReloadScene()
    {
        GameObject gameManager = GameObject.Find("GameManager"); // Find and activate script. 
        DataManager dataManager = gameManager.GetComponent<DataManager>();
        dataManager.DestroyMe(); // Destroy the old copy so that we refresh with a new data set. 
        SceneManager.LoadScene(0);
    }
    
    void LoadData()
    {
        GameObject gameManager = GameObject.Find("GameManager"); // Find and activate script. 
        dataManager = gameManager.GetComponent<DataManager>();
        finishDelay = dataManager.GetFinishDelay(); 
    }
}
