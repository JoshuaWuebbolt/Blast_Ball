using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float amplitude = 2f; // How far up and down the platform moves
    public float speed = 1f;     // How fast the platform moves

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
