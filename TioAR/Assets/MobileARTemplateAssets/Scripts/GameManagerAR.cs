using UnityEngine;
using TMPro;
using System.Collections;

public class GameManagerAR : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;

    [Header("End Screen")]
    public GameObject endPanel;
    public TMP_Text finalScoreText;

    [Header("Prefab")]
    public GameObject tioPrefab;

    [Header("UI")]
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public SearchMessage searchMessage;

    [Header("Rounds")]
    public float[] roundTimes = { 8f, 6f, 4f };

    [Header("Music")]
    public GameObject gameMusic;

    [Header("Messages")]
    public TimedMessage hitMessage;

    private int currentRound = 0;
    private float timeLeft;
    private int score = 0;
    private bool roundActive = false;

    private GameObject currentTio;


    void Awake()
    {
        // ocultar textos al inicio
        if (timeText != null) timeText.gameObject.SetActive(false);
        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (searchMessage != null) searchMessage.gameObject.SetActive(false);

        // asegurar paneles
        if (startPanel != null) startPanel.SetActive(true);
        if (endPanel != null) endPanel.SetActive(false);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

        if (gameMusic != null)
            gameMusic.SetActive(true);

        currentRound = 0;
        score = 0;

        // mostrar HUD
        if (timeText != null) timeText.gameObject.SetActive(true);
        if (scoreText != null) scoreText.gameObject.SetActive(true);
        if (searchMessage != null) searchMessage.gameObject.SetActive(true);

        UpdateUI();
        StartCoroutine(RoundLoop());
    }

IEnumerator RoundLoop()
{
    while (currentRound < roundTimes.Length)
    {
        // mensaje "Busca al Tió" (NO cuenta tiempo)
        yield return StartCoroutine(searchMessage.ShowMessage());

        // spawn del Tió en posición aleatoria
        SpawnTio();

        // bis — mensaje "Golpea al Tió"
        if (hitMessage != null)
            yield return StartCoroutine(hitMessage.Show());

        // iniciar ronda
        timeLeft = roundTimes[currentRound];
        roundActive = true;

        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            UpdateUI();
            yield return null;
        }

        // fin de ronda
        roundActive = false;

        if (currentTio != null)
            Destroy(currentTio);

        currentRound++;
    }

    EndGame();
}

    void SpawnTio()
    {
        Vector3 randomOffset =
            Camera.main.transform.forward * Random.Range(4f, 6f) +
            Camera.main.transform.right * Random.Range(-2f, 2f);

        Vector3 spawnPos = Camera.main.transform.position + randomOffset;

        currentTio = Instantiate(tioPrefab, spawnPos, Quaternion.identity);
    }

    public void RegisterHit()
    {
        if (!roundActive) return;

        score++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (timeText != null)
            timeText.text = "TIEMPO: " + Mathf.CeilToInt(timeLeft);

        if (scoreText != null)
            scoreText.text = "PUNTOS: " + score;
    }

    void EndGame()
    {

        if (gameMusic != null)
            gameMusic.SetActive(false);
        // ocultar HUD
        if (timeText != null) timeText.gameObject.SetActive(false);
        if (scoreText != null) scoreText.gameObject.SetActive(false);

        // mostrar pantalla final
        endPanel.SetActive(true);

        // mostrar puntuación final
        finalScoreText.text = "PUNTUACIÓN FINAL\n" + score;
    }

    public void RestartGame()
    {
        StopAllCoroutines();

        currentRound = 0;
        score = 0;
        roundActive = false;

        if (gameMusic != null)
            gameMusic.SetActive(true);

        if (timeText != null)
        {
            timeText.gameObject.SetActive(true);
            timeText.text = "";
        }

        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "PUNTOS: 0";
        }

        if (searchMessage != null)
            searchMessage.gameObject.SetActive(true);

        endPanel.SetActive(false);

        if (currentTio != null)
            Destroy(currentTio);

        StartCoroutine(RoundLoop());
    }
}
