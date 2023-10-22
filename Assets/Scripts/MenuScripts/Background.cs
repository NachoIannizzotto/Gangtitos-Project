using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float transitionDuration = 2.0f;
    private CanvasRenderer canvasRenderer;
    private Color startColor = Color.red;
    private Color targetColor = Color.black;
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
            canvasRenderer.SetColor(Color.Lerp(startColor, targetColor, t));
        }
    }
}

