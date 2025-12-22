using System.Collections;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    [Header("Intro UI")]
    [SerializeField] private CanvasGroup introCanvasGroup;   
    [SerializeField] private GameObject gameplayCanvas;      

    [Header("AR Objects")]
    [SerializeField] private GameObject arSession;           // AR Session
    [SerializeField] private GameObject xrOrigin;            // XR Origin (AR Rig)

    [Header("Timings")]
    [SerializeField] private float introDuration = 2f;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        // Seguridad: evita NullReference si olvidamos asignar algo
        if (introCanvasGroup == null)
        {
            Debug.LogError("[IntroController] Falta asignar introCanvasGroup (CanvasGroup de Canvas_Intro).");
            enabled = false;
            return;
        }
        if (gameplayCanvas == null)
        {
            Debug.LogError("[IntroController] Falta asignar gameplayCanvas (tu objeto 'Canvas' del juego).");
            enabled = false;
            return;
        }
        if (arSession == null || xrOrigin == null)
        {
            Debug.LogError("[IntroController] Falta asignar arSession y/o xrOrigin.");
            enabled = false;
            return;
        }

        // Intro visible al inicio
        introCanvasGroup.alpha = 1f;
        introCanvasGroup.interactable = true;
        introCanvasGroup.blocksRaycasts = true;

        // Apaga gameplay + AR mientras se muestra la intro
        gameplayCanvas.SetActive(false);
        arSession.SetActive(false);
        xrOrigin.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(IntroFlow());
    }

    private IEnumerator IntroFlow()
    {
        yield return new WaitForSeconds(introDuration);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            introCanvasGroup.alpha = 1f - Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        // Apaga intro
        introCanvasGroup.alpha = 0f;
        introCanvasGroup.interactable = false;
        introCanvasGroup.blocksRaycasts = false;
        introCanvasGroup.gameObject.SetActive(false);

        // Enciende gameplay + AR
        gameplayCanvas.SetActive(true);
        arSession.SetActive(true);
        xrOrigin.SetActive(true);
    }
}
