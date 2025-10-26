using UnityEngine;
using TMPro; // omit if using legacy UI.Text

public class PopupText : MonoBehaviour
{
    [SerializeField] float duration = 2f;   // seconds on screen
    TextMeshProUGUI text;                   // or UnityEngine.UI.Text if using legacy
    float timer;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false); // should be false by default. 

    }

    public void Show(string message)
    {
        text.text = message;
        gameObject.SetActive(true);
        timer = duration;
    }

    void Update()
    {
        if (!gameObject.activeSelf) return;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}