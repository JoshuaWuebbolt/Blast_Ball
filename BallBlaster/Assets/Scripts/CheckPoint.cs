using UnityEngine;


public class CheckPoint : MonoBehaviour
{
    public StarterAssets.FirstPersonController firstPersonController; // Assign in Inspector
    public AudioClip checkpointSound; // Assign in Inspector
    private AudioSource audioSource;
    private bool checkpointActivated = false;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private static AudioSource sharedAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActivated && other.CompareTag("Player"))
        {
            checkpointActivated = true;

            // Use a shared AudioSource for all checkpoints
            if (sharedAudioSource == null)
            {
                sharedAudioSource = gameObject.AddComponent<AudioSource>();
            }

            // Play checkpoint sound, stopping any previous sound
            if (checkpointSound != null)
            {
                sharedAudioSource.Stop();
                sharedAudioSource.clip = checkpointSound;
                sharedAudioSource.Play();
            }

            // Set this location as the new spawn point
            firstPersonController.spawnPosition = transform.position;
        }
    }
}
