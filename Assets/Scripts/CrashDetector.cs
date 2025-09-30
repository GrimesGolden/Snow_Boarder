using UnityEngine;
using UnityEngine.SceneManagement; 

public class CrashDetector : MonoBehaviour
{
    int count = 0; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Terrain")
        {
            SceneManager.LoadScene(0); 
        }
    }
}
