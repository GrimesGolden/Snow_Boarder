using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.0f;
    [SerializeField] ParticleSystem finishEffect;

    bool finish = false; 
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
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {   
        GameObject gameManager = GameObject.Find("GameManager"); // Find and activate script. 
        Manager manager = gameManager.GetComponent<Manager>();
        manager.DestroyMe(); // This needs refactor. 
        SceneManager.LoadScene(0);
    }
}
