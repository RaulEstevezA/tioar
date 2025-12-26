using UnityEngine;
using UnityEngine.EventSystems;

public class TioHitSound : MonoBehaviour, IPointerClickHandler
{
    public AudioClip[] hitSounds;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayRandomHit();
    }

    void PlayRandomHit()
    {
        if (hitSounds.Length == 0) return;

        AudioClip clip = hitSounds[Random.Range(0, hitSounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}