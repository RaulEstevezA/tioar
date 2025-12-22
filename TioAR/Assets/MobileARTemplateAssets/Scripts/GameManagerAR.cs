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
    public float[] roundTimes = { 10f, 8f, 4f };

    private int currentRound = 0;
    private float timeLeft;
    private int score = 0;
    private bool roundActive = false;

    private GameObject currentTio;


    public void StartGame()
    {
        startPanel.SetActive(false);

        currentRound = 0;
        score = 0;

        if (timeText != null) timeText.gameObject.SetActive(true);
        if (scoreText != null) scoreText.gameObject.SetActive(true);

        UpdateUI();
        StartCoroutine(RoundLoop());
    }

    IEnumerator RoundLoop()
    {
        while (currentRound < roundTimes.Length)
        {
            // 1️⃣ mensaje "Busca al Tió" (NO cuenta tiempo)
            yield return StartCoroutine(searchMessage.ShowMessage());

            // 2️⃣ spawn del Tió en posición aleatoria
            SpawnTio();

            // 3️⃣ iniciar ronda
            timeLeft = roundTimes[currentRound];
            roundActive = true;

            while (timeLeft > 0f)
            {
                timeLeft -= Time.deltaTime;
                UpdateUI();
                yield return null;
            }

            // 4️⃣ fin de ronda
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

        endPanel.SetActive(false);

        if (currentTio != null)
            Destroy(currentTio);

        StartCoroutine(RoundLoop());
    }
}
