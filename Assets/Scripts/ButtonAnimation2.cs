using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonAnimation2 : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI messageText2;
    public TextMeshProUGUI messageText3;
    public TextMeshProUGUI messageText4;
    public TextMeshProUGUI messageText5;
    public float delayBeforeAppear = 3.0f;
    public float appearDuration = 2.0f;

    private float currentTime = 0.0f;
    private bool isMessageVisible = false;

    private void Start()
    {
        messageText.alpha = 0f;
        messageText2.alpha = 0f;
        messageText3.alpha = 0f;
        messageText4.alpha = 0f;
        messageText5.alpha = 0f;
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
            messageText4.alpha = t;
            messageText5.alpha = t;
        }
    }
}
