using UnityEngine;
using System.Collections;

public class GameManagerAR : MonoBehaviour
{
    public GameObject tioPrefab;
    public float roundTime = 10f;

    private GameObject currentTio;
    private int score = 0;
    private bool roundActive = false;

    void Start()
    {
        StartCoroutine(StartRound());
    }

    IEnumerator StartRound()
    {
        // esperamos a que termine el mensaje "Busca al Tió"
        yield return new WaitForSeconds(5f);

        SpawnTio();
        roundActive = true;

        yield return new WaitForSeconds(roundTime);
        EndRound();
    }

    void SpawnTio()
    {
        if (tioPrefab == null)
        {
            Debug.LogError("Tio Prefab no asignado en GameManagerAR");
            return;
        }

        Vector3 spawnPos = Camera.main.transform.position
                         + Camera.main.transform.forward * 6f;

        currentTio = Instantiate(tioPrefab, spawnPos, Quaternion.identity);
    }

    public void RegisterHit()
    {
        if (!roundActive) return;

        score++;
        Debug.Log("Puntos: " + score);
    }

    void EndRound()
    {
        roundActive = false;
        Debug.Log("Ronda terminada. Puntos finales: " + score);
    }
}