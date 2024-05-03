// this was basically to give the tv on off effect 


using UnityEngine;
using UnityEngine.UI;

public class spritefadein : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Button fadeButton;
    public GameObject enableGameObject; // GameObject to enable after fade in
    public float fadeDuration = 1.0f; // Duration of the fade effect

    private bool fadingIn = false;
    private bool fadingOut = false;
    private float currentAlpha = 0.0f;
    private float fadeStartTime;

    void Start()
    {
        if (spriteRenderer == null)
        {
            // If SpriteRenderer reference is not set, try to get it from the GameObject
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            // Set the initial alpha value to 0
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0.0f;
            spriteRenderer.color = spriteColor;
        }
        else
        {
            Debug.LogError("SpriteRenderer reference is missing.");
        }

        if (fadeButton != null)
        {
            fadeButton.onClick.AddListener(ToggleFade);
        }
        else
        {
            Debug.LogError("Fade Button reference is missing.");
        }
    }

    void Update()
    {
        if (fadingIn || fadingOut)
        {
            // Calculate the alpha value based on the elapsed time
            float elapsedTime = Time.time - fadeStartTime;
            currentAlpha = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Apply the new alpha value to the sprite color
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = currentAlpha;
            spriteRenderer.color = spriteColor;

            // Enable the GameObject after fade in is complete
            if (fadingIn && currentAlpha >= 1.0f)
            {
                fadingIn = false;
                if (enableGameObject != null)
                {
                    enableGameObject.SetActive(true);
                }
            }

            // Disable the GameObject when fade out is initiated
            if (fadingOut && currentAlpha <= 0.0f)
            {
                fadingOut = false;
                if (enableGameObject != null)
                {
                    enableGameObject.SetActive(false);
                }
            }

            // Disable the script once the fade-in or fade-out is complete
            if ((fadingIn && currentAlpha >= 1.0f) || (fadingOut && currentAlpha <= 0.0f))
            {
                // enabled = false; // You can optionally disable the script here
            }
        }
    }

    void ToggleFade()
    {
        if (currentAlpha <= 0.0f)
        {
            // If currentAlpha is 0, start fading in
            StartFadeIn();
        }
        else if (currentAlpha >= 1.0f)
        {
            // If currentAlpha is 1, start fading out
            StartFadeOut();
        }
        else if (fadingIn)
        {
            // If fading in is active, start fading out
            StartFadeOut();
        }
        else if (fadingOut)
        {
            // If fading out is active, start fading in
            StartFadeIn();
        }
    }

    void StartFadeIn()
    {
        // Start fading in
        fadingIn = true;
        fadingOut = false;
        fadeStartTime = Time.time;
    }

    void StartFadeOut()
    {
        // Start fading out
        fadingIn = false;
        fadingOut = true;
        fadeStartTime = Time.time;
    }
}

