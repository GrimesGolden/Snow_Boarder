// Persisted across scenes:
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager I { get; private set; }

    const int MaxHealth = 3;
    public int Health;

    public Image[] hearts;

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject); // Keep the old manager and don't delete the old one

        // Initialize once per app run (could also load from PlayerPrefs here)
        Health = MaxHealth;
    }

    public void DestroyMe()
    {
        Destroy(LevelManager.I.gameObject);
        LevelManager.I = null;
    }

    public void TakeDamage()
    {
        Health--;
        ReloadScene();
    }
    public void ReloadScene()
    {
        if (Health <= 0)
        {
            // Explicitely destroy. 
            Destroy(LevelManager.I.gameObject);
            LevelManager.I = null;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
