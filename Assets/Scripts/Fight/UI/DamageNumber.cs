using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText; // Reference to the Text component

    public void SetDamageText(float damageAmount)
    {
        damageText.text = damageAmount.ToString();
    }

    public void Animate()
    {
        // Example: Fade out and move up
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        float duration = 1f; // Total time for the animation
        float elapsedTime = 0f;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.up * 50f; // Move up by 50 units

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>(); // Ensure it has a CanvasGroup

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Move the damage number upward
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);

            // Fade out the damage number
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            yield return null;
        }

        // Destroy the damage number object after animation
        Destroy(gameObject);
    }
}