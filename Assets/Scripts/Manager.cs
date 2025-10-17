// Persisted across scenes:
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager I { get; private set; }

    public int MaxHealth = 3;
    public int Health;

   // public Image[] hearts;

    public void Start()
    {
      //
    }

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject); // Keep the old manager and don't delete the old one

        // Initialize once per app run (could also load from PlayerPrefs here)
        Health = MaxHealth;
    }

    public void TakeDamage()
    {
        Health--;
        RefreshHearts();
    }

    public void RefreshHearts()
    {  
        if (Health <= 0)
        {   
            // Explicitely destroy. 
            Destroy(Manager.I.gameObject);
            Manager.I = null;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
