using UnityEditor.Rendering;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool isHit = false;

    [Tooltip("Set the target that will be activated upon hit.")]
    public GameObject targetObject;

    void Update()
    {
        // Rotate the object continuously in x, y, z axes
        transform.Rotate(new Vector3(1f, 1f, 1f) * Time.deltaTime * 50f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ball"))
        {
            isHit = true;
            Debug.Log("Target hit!");

            // Make a given object active (replace "objectToActivate" with your reference)
            GameObject objectToActivate = targetObject; // Assign this in the Inspector
            if (objectToActivate != null)
            {
                Debug.Log("Activating target object: " + objectToActivate.name);
                objectToActivate.SetActive(true);
            }
        }
    }
}
