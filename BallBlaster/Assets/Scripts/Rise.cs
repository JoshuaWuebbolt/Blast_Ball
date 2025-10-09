using UnityEngine;

public class Rise : MonoBehaviour
{
    public float riseAmount = 5f; // Amount to rise in units
    public float riseSpeed = 2f;  // Speed of rising

    private Vector3 targetPosition;
    private bool rising = false;

    void Start()
    {
        targetPosition = transform.position + Vector3.up * riseAmount;
        rising = true;
    }
    public AudioSource audioSource;

    public AudioClip riseClip; // User-specified sound

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rising)
        {
            if (!audioSource.isPlaying)
            {
                if (riseClip != null)
                {
                    audioSource.clip = riseClip;
                    audioSource.Play();
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, riseSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                rising = false;
                audioSource.Stop();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
