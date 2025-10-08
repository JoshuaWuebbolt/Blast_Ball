using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public StarterAssets.FirstPersonController firstPersonController; // Assign in Inspector
    public float maxShootForce = 0f;
    public Vector3 minScale = Vector3.zero;
    public Vector3 maxScale = new Vector3(1f, 1f, 1f);
    public Renderer barRenderer; // Assign in Inspector

    public Color normalColor = Color.black;
    public Color maxColor = Color.red;

    public Image chargeBarImage; // Assign in Inspector

    void Start()
    {
        maxShootForce = firstPersonController.maxShootForce;
    }

    void Update()
    {
        float currentShootForce = StarterAssets.FirstPersonController.currentShootForce;
        float t = Mathf.Clamp01(currentShootForce / maxShootForce);

        // Ensure maxScale is reached only when fully charged
        Vector3 targetScale = (Mathf.Approximately(t, 1f)) ? maxScale : Vector3.Lerp(minScale, maxScale, t);
        transform.localScale = targetScale;

        if (chargeBarImage != null)
        {
            Debug.Log($"Charge ratio: {t}");
            // Change color when fully charged
            Color targetColor = Mathf.Approximately(t, 1f) ? maxColor : normalColor;
            chargeBarImage.canvasRenderer.SetColor(targetColor);
        }
    }
}
