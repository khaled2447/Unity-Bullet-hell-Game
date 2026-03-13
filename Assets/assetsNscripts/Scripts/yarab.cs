using UnityEngine;

public class CameraBoxFollow3D : MonoBehaviour
{
    public Transform player;
    public Vector2 halfSize = new Vector2(3f, 2f); // X = horizontal, Z = depth
    public float height = 5f; // Y position of camera

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        // Horizontal
        float dx = player.position.x - pos.x;
        if (Mathf.Abs(dx) > halfSize.x)
            pos.x = player.position.x - Mathf.Sign(dx) * halfSize.x;

        // Depth (forward/back)
        float dz = player.position.z - pos.z;
        if (Mathf.Abs(dz) > halfSize.y)
            pos.z = player.position.z - Mathf.Sign(dz) * halfSize.y;

        // Fixed height
        pos.y = height;

        transform.position = pos;
    }
}