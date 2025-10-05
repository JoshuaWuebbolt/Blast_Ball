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
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
        
    }

    void Shoot() 
    {
        Vector2 pos = Mouse.current.position.ReadValue();
        // Ray ray = playerCamera.ScreenPointToRay(pos);
        // if (Physics.Raycast(ray, out var hit, range))
        // {
            // Debug.Log(hit.transform.name);
            // Spawn the effect at the hit point, facing the surface normal
            var create = Instantiate(hitEffectPrefab, playerCamera.transform.position + playerCamera.transform.forward * 1f, Quaternion.LookRotation(playerCamera.transform.forward));
            Rigidbody rb = create.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = playerCamera.transform.forward * shootForce;
            }
        // }
    }
}
