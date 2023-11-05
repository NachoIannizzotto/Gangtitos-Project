using UnityEngine;
using TMPro;
using System;

public class VHSDateTime : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public int startYear = 1989;
    public int startMonth;
    public int startDay;

    private void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("No data");
            enabled = false;
            return;
        }

        DateTime fechaActual = DateTime.Now;
        startMonth = fechaActual.Month;
        startDay = fechaActual.Day;

        string dateText = string.Format("{0:D2}.{1:D2}.{2:D4}", startMonth, startDay, startYear);

        textMeshPro.text = "" + dateText;
    }
}






















