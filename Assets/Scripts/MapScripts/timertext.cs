using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class timertext : MonoBehaviour
{
    public TMP_Text texto1;
    public TMP_Text texto2;
    public TMP_Text texto3;
    public TMP_Text texto4;

    [SerializeField]
    private float tiempoTexto1 = 2.0f;
    [SerializeField]
    private float tiempoTexto2 = 5.0f;
    [SerializeField]
    private float tiempoTexto3 = 3.0f;
    [SerializeField]
    private float tiempoTexto4 = 4.0f;

    private void Start()
    {
        StartCoroutine(AlternarTextos());
    }

    private IEnumerator AlternarTextos()
    {
        while (true)
        {
            texto1.enabled = true;
            yield return new WaitForSeconds(tiempoTexto1);
            texto1.enabled = false;

            texto2.enabled = true;
            yield return new WaitForSeconds(tiempoTexto2);
            texto2.enabled = false;

            texto3.enabled = true;
            yield return new WaitForSeconds(tiempoTexto3);
            texto3.enabled = false;

            texto4.enabled = true;
            yield return new WaitForSeconds(tiempoTexto4);
            texto4.enabled = false;

            Destroy(texto1.gameObject);
            Destroy(texto2.gameObject);
            Destroy(texto3.gameObject);
            Destroy(texto4.gameObject);

            SceneManager.LoadScene("TestLevel");

            yield break;
        }
    }
}

