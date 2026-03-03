using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 5f;
    [SerializeField] float fadeRate = 0.25f;

    private CanvasGroup canvasGroup;
    private float startTimer;
    private float fadeoutTimer;

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;

        startTimer = Time.time + delayInSeconds;
        fadeoutTimer = fadeRate;
    }

    void Update()
    {
        // time to fade out?
        if (Time.time >= startTimer)
        {
            fadeoutTimer -= Time.deltaTime;

            // fade out complete?
            if (fadeoutTimer <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                // reduce the alpha value
                canvasGroup.alpha = fadeoutTimer / fadeRate;
            }
        }
    }
}
