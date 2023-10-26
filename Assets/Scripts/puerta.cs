using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    public int cantidadNecesaria = 5;

    private Contador contador;

    public GameObject door1;
    public GameObject door2;

    public AudioClip open;
    public AudioSource audioS2;
    private void Start()
    {
        audioS2 = GetComponent<AudioSource>();
        audioS2.clip = open;
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        contador = jugador.GetComponent<Contador>();
    }

    private void Update()
    {

        if (contador != null && contador.GetContador() >= cantidadNecesaria)
        {

            audioS2.Play();
            StartCoroutine(effectRoutine());
        }
    }
 
    IEnumerator effectRoutine()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}