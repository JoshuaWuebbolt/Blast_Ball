using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool isHit = false;

    [Tooltip("Set the target's name in the Inspector.")]
    public string targetName;

    void Update()
    {
        // You can use isHit elsewhere in your logic
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ball"))
        {
            isHit = true;
            Debug.Log("Target hit!");
        }
    }
}
