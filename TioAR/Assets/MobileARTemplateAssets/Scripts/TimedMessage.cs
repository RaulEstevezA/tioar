using UnityEngine;
using System.Collections;

public class TimedMessage : MonoBehaviour
{
    public float displayTime = 2f;

    public IEnumerator Show()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}