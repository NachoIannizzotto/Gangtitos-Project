using UnityEngine;
using System.Collections.Generic;

public class LowVolume : MonoBehaviour
{
    public List<AudioSource> audioSources;
    public float tiempoParaBajarVolumen = 2.0f;

    private bool bajandoVolumen = false;
    private List<float> volumenesIniciales;
    private float tiempoTranscurrido = 0.0f;

    void Start()
    {
        volumenesIniciales = new List<float>();
        foreach (var audioSource in audioSources)
        {
            volumenesIniciales.Add(audioSource.volume);
        }
    }

    void Update()
    {
        if (bajandoVolumen)
        {
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido < tiempoParaBajarVolumen)
            {
                for (int i = 0; i < audioSources.Count; i++)
                {
                    float nuevoVolumen = Mathf.Lerp(volumenesIniciales[i], 0.0f, tiempoTranscurrido / tiempoParaBajarVolumen);
                    audioSources[i].volume = nuevoVolumen;
                }
            }
            else
            {
                for (int i = 0; i < audioSources.Count; i++)
                {
                    audioSources[i].volume = 0.0f;
                }
                bajandoVolumen = false;
            }
        }
    }

    public void BajarVolumen()
    {
        bajandoVolumen = true;
        tiempoTranscurrido = 0.0f;
    }
}