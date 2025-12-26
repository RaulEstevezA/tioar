using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButton : MonoBehaviour
{
    public Image icon;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;

    void Start()
    {
        UpdateIcon();
    }

    public void ToggleSound()
    {
        // alternar volumen global
        AudioListener.volume = AudioListener.volume > 0f ? 0f : 1f;

        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (AudioListener.volume > 0f)
            icon.sprite = soundOnIcon;
        else
            icon.sprite = soundOffIcon;
    }
}