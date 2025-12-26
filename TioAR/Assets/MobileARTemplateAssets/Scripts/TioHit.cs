using UnityEngine;
using UnityEngine.EventSystems;

public class TioHit : MonoBehaviour, IPointerClickHandler
{
    private GameManagerAR gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerAR>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameManager != null)
        {
            gameManager.RegisterHit();
        }
    }
}