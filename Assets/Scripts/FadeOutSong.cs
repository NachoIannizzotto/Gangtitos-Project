using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSong : MonoBehaviour
{
    public AudioSource audioSource;
    private float volumenOriginal;

    void Start()
    {
        volumenOriginal = audioSource.volume;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOutAudio(0.5f));
        }
    }

    private IEnumerator FadeOutAudio(float duration)
    {
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(volumenOriginal, 0, currentTime / duration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }
}

