using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llaves : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private bool collected = false;

    public GameObject key1;
    public GameObject key2;

    public AudioClip pickup;
    public AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.clip = pickup;
    }
    void Update()
    {
        if (!collected)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("Player"))
        {

            collected = true;

            Contador contador = other.GetComponent<Contador>();
            if (contador != null)
            {
                contador.AumentarContador(1);
            }
            audioS.Play();
            StartCoroutine(effectRoutine());
        }
    }

    IEnumerator effectRoutine()
    {
        key1.SetActive(false);
        key2.SetActive(false);
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}