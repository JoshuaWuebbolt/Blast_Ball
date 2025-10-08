using UnityEngine;
using UnityEngine.InputSystem;

public class OutOfBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position;
    }
    // Check for collision with OOB tagged objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OOB"))
        {
            Debug.Log("Player went out of bounds. Respawning...");
            // Respawn the player at a designated spawn point
            Debug.Log("Respawning player at: " + transform.position);
            transform.position = spawnPosition;
            Debug.Log("Player respawned at: " + transform.position);
            // Optionally reset velocity if using Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }


    }

    // Update is called once per frame    
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Right mouse button clicked!");
            Debug.Log("The object is : " + gameObject.name + " and its position is: " + transform.position);
            transform.position = new Vector3(1, 1, 1);
            Debug.Log("The object new position is: " + transform.position);
            
        }
    }


}
