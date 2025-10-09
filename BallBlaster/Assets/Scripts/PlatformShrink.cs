using UnityEngine;

public class PlatformShrink : MonoBehaviour
{
    public float shrinkDuration = 1f; // Time to shrink
    public float growDuration = 1f;   // Time to grow
    private Vector3 originalScale;
    private float timer = 0f;
    private bool shrinking = true;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (shrinking)
        {
            float t = Mathf.Clamp01(timer / shrinkDuration);
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);

            if (t >= 1f)
            {
                shrinking = false;
                timer = 0f;
            }
        }
        else
        {
            float t = Mathf.Clamp01(timer / growDuration);
            transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);

            if (t >= 1f)
            {
                shrinking = true;
                timer = 0f;
            }
        }
    }
}
