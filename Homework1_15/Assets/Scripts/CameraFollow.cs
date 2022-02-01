using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    public Vector3 CameraOffset;
    public float CameraSpeed;

    void Update()
    {
        if (Player.CurrentPlatform == null) return;

        Vector3 targetPosition = Player.CurrentPlatform.transform.position + CameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, CameraSpeed * Time.deltaTime);
    }
}
