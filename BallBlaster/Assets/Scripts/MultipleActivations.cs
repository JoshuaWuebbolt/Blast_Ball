using UnityEngine;

public class MultipleActivations : MonoBehaviour
{
    [Tooltip("Array of objects to be activated.")]
    [SerializeField] public GameObject[] objectsToActivate;

    // Call this method to activate all objects in the array
    public void Awake()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
