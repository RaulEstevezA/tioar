using UnityEngine;
using System.Collections;

public class SearchMessage : MonoBehaviour
{
    public float displayTime = 5f;

    public IEnumerator ShowMessage()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}