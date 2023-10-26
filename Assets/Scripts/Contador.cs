using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    [SerializeField]
    private int contador = 0;

    public int GetContador()
    {
        return contador;
    }

    public void AumentarContador(int cantidad)
    {
        contador += cantidad;
    }
}