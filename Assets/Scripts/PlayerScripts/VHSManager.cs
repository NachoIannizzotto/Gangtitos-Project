using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSManager : MonoBehaviour
{
    public static VHSManager instance;

    public Canvas canvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyVHS()
    {
        Destroy(canvas.gameObject);
    }
}
