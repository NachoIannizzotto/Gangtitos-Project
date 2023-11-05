using UnityEngine;

public class RECBehavior : MonoBehaviour
{
    public GameObject circuloRojo; // Arrastra el GameObject del c�rculo rojo aqu�
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

        // Cambiar la visibilidad del c�rculo en funci�n de la frecuencia de parpadeo
        if (tiempoTranscurrido >= periodoParpadeo)
        {
            tiempoUltimoCambio = Time.time;
            bool visible = !circuloRojo.activeSelf;
            circuloRojo.SetActive(visible);
        }
    }
}


