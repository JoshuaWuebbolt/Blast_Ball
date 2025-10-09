using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public StarterAssets.FirstPersonController firstPersonController; // Assign in Inspector
    public float maxShootForce = 0f;
    public Vector3 minScale = Vector3.zero;
    public Vector3 maxScale = new Vector3(2f, 2f, 2f);
    public Renderer barRenderer; // Assign in Inspector

    public Color normalColor = Color.black;
    public Color maxColor = Color.red;

    public Image chargeBarImage; // Assign in Inspector

    void Start()
    {
        maxShootForce = StarterAssets.FirstPersonController.maxShootForceStatic;
    }

    void Update()
    {
        float currentShootForce = StarterAssets.FirstPersonController.currentShootForce;
        maxShootForce = StarterAssets.FirstPersonController.maxShootForceStatic;
        float t = (currentShootForce / maxShootForce);

        if (currentShootForce != 0f)
        {
            Debug.Log($"Current Shoot Force: {currentShootForce}, Max Shoot Force: {maxShootForce}, Ratio: {t}");
        }

        // Allow the bar to go over maxScale when t > 1
        Vector3 targetScale;
        if (t <= 1f)
        {
            targetScale = Vector3.Lerp(minScale, maxScale, t);
        }
        else
        {
            // Extend beyond maxScale proportionally
            targetScale = maxScale * t;
        }
        transform.localScale = targetScale;

        if (chargeBarImage != null)
        {
            Debug.Log($"Charge ratio: {t}");
            // Change color when fully charged or overcharged
            Color targetColor = t >= 1f ? maxColor : normalColor;
            chargeBarImage.canvasRenderer.SetColor(targetColor);
        }
    }
}
