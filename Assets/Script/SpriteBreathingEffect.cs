using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteBreathingEffect : MonoBehaviour
{

    private Image image;
    // Minimum and maximum scale values for the breathing effect
    public float minScale = 1.0f;
    public float maxScale = 1.1f;

    // Speed of the breathing effect
    public float speed = 1.0f;

    // Initial scale value
    private Vector3 initialScale;

    void Start()
    {
        image = GetComponent<Image>();
        // Store the initial scale
        initialScale = image.rectTransform.localScale;
    }

    void Update()
    {
        // Calculate the new scale factor based on a sinusoidal function
        float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);

        // Apply the new scale to the RectTransform
        image.rectTransform.localScale = initialScale * scaleFactor;
    }
}

