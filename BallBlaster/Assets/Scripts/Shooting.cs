using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject hitEffectPrefab;
    public float range = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float shootForce = 100f;
    void Start()
    {

        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
    //     {
    //         Shoot();
    //     }
        
    // }

    private float currentShootForce = 0f;
    private bool isCharging = false;
    private float maxShootForce = 50f;
    private float chargeRate = 50f; // units per second

    void Update()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.isPressed)
            {
                isCharging = true;
                currentShootForce += chargeRate * Time.deltaTime;
                currentShootForce = Mathf.Min(currentShootForce, maxShootForce * 2f); // allow overcharge
            }
            else if (isCharging && Mouse.current.leftButton.wasReleasedThisFrame)
            {
                if (currentShootForce > maxShootForce)
                {
                    LaunchPlayer();
                }
                else
                {
                    Shoot();
                }
                currentShootForce = 0f;
                isCharging = false;
            }
        }
    }

    void Shoot() 
    {
        Vector2 pos = Mouse.current.position.ReadValue();

        var create = Instantiate(hitEffectPrefab, playerCamera.transform.position + playerCamera.transform.forward * 1f, Quaternion.LookRotation(playerCamera.transform.forward));
        Rigidbody rb = create.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = playerCamera.transform.forward * currentShootForce;
        }
    }

    void LaunchPlayer()
    {
        Debug.Log("Launching player!");
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            Debug.Log("CharacterController found, applying launch movement.");
            // Calculate launch direction and force
            float launchForce = Mathf.Max(currentShootForce - maxShootForce, 10f);
            Vector3 launchDirection = -playerCamera.transform.forward * launchForce;

            // Move the player using CharacterController
            controller.Move(launchDirection * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("No Rigidbody or CharacterController found on player for launching.");
        }
    }
}
