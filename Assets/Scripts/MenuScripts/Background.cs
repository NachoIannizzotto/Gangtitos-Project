using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float transitionDuration = 2.0f;
    private CanvasRenderer canvasRenderer;
    private Color startColor = Color.white;
    private Color targetColor = new Color(0, 0, 0, 0); // Color negro con alpha 0
    private float currentTime = 0.0f;

    private void Start()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
        canvasRenderer.SetColor(startColor);
    }

    private void Update()
    {
        if (currentTime < transitionDuration)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / transitionDuration;
            Color lerpedColor = Color.Lerp(startColor, targetColor, t);
            canvasRenderer.SetColor(lerpedColor);
        }
    }
}

