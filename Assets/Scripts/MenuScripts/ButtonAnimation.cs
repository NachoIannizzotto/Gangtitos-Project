using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonAnimation : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI messageText2;
    public TextMeshProUGUI messageText3;
    public float delayBeforeAppear = 3.0f; // Retraso en segundos antes de que aparezca el mensaje
    public float appearDuration = 2.0f; // Duración de la aparición en segundos

    private float currentTime = 0.0f;
    private bool isMessageVisible = false;

    private void Start()
    {
        messageText.alpha = 0f; // Inicialmente, el mensaje está completamente transparente
        messageText2.alpha = 0f;
        messageText3.alpha = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= delayBeforeAppear && !isMessageVisible)
        {
            float t = (currentTime - delayBeforeAppear) / appearDuration;
            if (t >= 1.0f)
            {
                t = 1.0f;
                isMessageVisible = true;
            }
            messageText.alpha = t;
            messageText2.alpha = t;
            messageText3.alpha = t;
        }
    }
}