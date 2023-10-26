using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour
{
    public int cantidadNecesaria = 5;

    private Contador contador;

    public AudioClip keylocker;
    public AudioSource audioSource1;

    private void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        contador = jugador.GetComponent<Contador>();
        audioSource1 = GetComponent<AudioSource>();
        audioSource1.clip = keylocker;
    }

    private void Update()
    {

        if (contador != null && contador.GetContador() >= cantidadNecesaria)
        {
            audioSource1.Play();
            StartCoroutine(unlockRoutine());

        }
    }

    IEnumerator unlockRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

}