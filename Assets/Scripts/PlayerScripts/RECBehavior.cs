using UnityEngine;

public class RECBehavior : MonoBehaviour
{
    public GameObject circuloRojo; // Arrastra el GameObject del círculo rojo aquí
    public float velocidadParpadeo = 1.0f; // Frecuencia de parpadeo (veces por segundo)

    private float tiempoUltimoCambio = 0f;

    private void Start()
    {
        tiempoUltimoCambio = Time.time;
    }

    private void FixedUpdate()
    {
        float tiempoTranscurrido = Time.time - tiempoUltimoCambio;
        float periodoParpadeo = 1.0f / velocidadParpadeo;

        // Cambiar la visibilidad del círculo en función de la frecuencia de parpadeo
        if (tiempoTranscurrido >= periodoParpadeo)
        {
            tiempoUltimoCambio = Time.time;
            bool visible = !circuloRojo.activeSelf;
            circuloRojo.SetActive(visible);
        }
    }
}


