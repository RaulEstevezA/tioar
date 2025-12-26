using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class IntroController : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject startPanel;

    public Image logo;
    public TMP_Text teamText;

    public float fadeDuration = 2f;
    public float visibleTime = 1f;

    void Start()
    {
        // intro visible al inicio
        introPanel.SetActive(true);

        // start panel oculto hasta que acabe la intro
        startPanel.SetActive(false);

        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        // asegurar inicio invisible
        SetAlpha(logo, 0f);
        SetAlpha(teamText, 0f);

        // fade in
        yield return StartCoroutine(FadeIn());

        // mantener visible
        yield return new WaitForSeconds(visibleTime);

        // fade out
        yield return StartCoroutine(FadeOut());

        // pasar a start panel
        introPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;

            SetAlpha(logo, alpha);
            SetAlpha(teamText, alpha);

            yield return null;
        }
    }

    void SetAlpha(Graphic g, float a)
    {
        Color c = g.color;
        c.a = a;
        g.color = c;
    }

    IEnumerator FadeOut()
    {
        float t = fadeDuration;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float alpha = t / fadeDuration;

            SetAlpha(logo, alpha);
            SetAlpha(teamText, alpha);

            yield return null;
        }
    }
}
