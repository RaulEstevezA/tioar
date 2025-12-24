using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    public static SoundMaster Instance;

    public bool soundEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        AudioListener.volume = soundEnabled ? 1f : 0f;
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
    }
}
