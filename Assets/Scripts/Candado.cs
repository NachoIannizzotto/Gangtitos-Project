using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour
{
    public int cantidadNecesaria = 5;

    private Contador contador;

    private void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        contador = jugador.GetComponent<Contador>();
    }

    private void Update()
    {

        if (contador != null && contador.GetContador() >= cantidadNecesaria)
        {

            Destroy(gameObject);

        }
    }

}