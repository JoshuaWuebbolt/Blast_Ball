using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [Header("References")]
    public GameObject player; // Assign the player GameObject in Inspector
    public AudioClip finishClip; // Assign the oneshot AudioClip in Inspector
    public string nextSceneName; // Set the name of the scene to load

    public AudioSource audioSource;
    private bool hasFinished = false;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasFinished && other.gameObject == player)
        {
            hasFinished = true;
            audioSource.PlayOneShot(finishClip);
            StartCoroutine(WaitAndChangeScene(finishClip.length));
        }
    }

    private System.Collections.IEnumerator WaitAndChangeScene(float waitTime)
    {
        Debug.Log("Level finished! Loading next scene: " + nextSceneName);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextSceneName);
    }
}
