using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject hitEffectPrefab;
    public float range = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    void Shoot() {

        Vector2 pos = Mouse.current.position.ReadValue();
        Ray ray = playerCamera.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out var hit, range))
        {
            Debug.Log(hit.transform.name);
            Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
