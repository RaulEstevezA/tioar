using UnityEngine;
using TMPro;
using System.Collections;

public class SearchMessage : MonoBehaviour
{
    public float displayTime = 5f;

    void Start()
    {
        StartCoroutine(ShowAndHide());
    }

    IEnumerator ShowAndHide()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}
