using UnityEngine;
using TMPro;

public class VHSTimeCounter : MonoBehaviour
{
    public TMP_Text textMeshPro;
    private int currentHour = 0;
    private int currentMinute = 0;
    private int currentSecond = 0;
    private bool isCounting = true;

    private void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("No se ha asignado un componente TextMeshPro. Asigne un componente TextMeshPro en el Inspector.");
            enabled = false;
            return;
        }

        // Inicia la actualización del tiempo transcurrido
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    private void UpdateTime()
    {
        if (isCounting)
        {
            currentSecond++;

            if (currentSecond >= 60)
            {
                currentSecond = 0;
                currentMinute++;

                if (currentMinute >= 60)
                {
                    currentMinute = 0;
                    currentHour++;
                }
            }

            string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", currentHour, currentMinute, currentSecond);

            // Actualiza el componente TextMeshPro con el tiempo transcurrido
            textMeshPro.text = "" + timeText;
        }
    }
}

