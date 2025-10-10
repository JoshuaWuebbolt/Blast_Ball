using UnityEngine;
using System.Collections.Generic;



public class Dummy : MonoBehaviour
{
    [Tooltip("The object to be activated when all enemies are defeated.")]
    public GameObject targetObject;

    [Tooltip("The group identifier for this enemy.")]
    public string groupId = "default";

    // Tracks remaining enemies per group
    private static Dictionary<string, int> enemiesLeftByGroup = new Dictionary<string, int>();

    void Start()
    {
        if (!enemiesLeftByGroup.ContainsKey(groupId))
        {
            enemiesLeftByGroup[groupId] = 0;
        }
        enemiesLeftByGroup[groupId] += 1;
        Debug.Log($"Number of enemies in group '{groupId}': {enemiesLeftByGroup[groupId]}");
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OOB"))
        {
            enemiesLeftByGroup[groupId]--;
            Debug.Log($"Number of enemies in group '{groupId}': {enemiesLeftByGroup[groupId]}");
            if (enemiesLeftByGroup[groupId] <= 0)
            {
                AllEnemiesDefeated();
            }
        }
    }

    private void AllEnemiesDefeated()
    {
        Debug.Log($"All enemies in group '{groupId}' defeated!");
        if (targetObject != null)
        {
            targetObject.SetActive(true);
            Debug.Log("Activated target object: " + targetObject.name);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
