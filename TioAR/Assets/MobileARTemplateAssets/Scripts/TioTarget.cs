using UnityEngine;

public class TioTarget : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main == null) return;

        Vector3 cameraPosition = Camera.main.transform.position;

        // solo rotamos en Y (horizontal), no en vertical
        Vector3 direction = cameraPosition - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }

    public void Hit()
    {
        Debug.Log("¡Tió golpeado!");
    }
}
