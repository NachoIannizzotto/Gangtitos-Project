using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public GameObject enemy;  // El GameObject del enemigo
    public float activationDelay = 2f;  // Retraso en segundos antes de activar el enemigo
    public AudioSource audioSource;  // El AudioSource para la m�sica
    public Animator cinematicAnimator;  // El Animator para la animaci�n "cinem�tica"
    public GameObject meshObject;  // El GameObject que contiene el Mesh Renderer
    public GameObject player;
    public GameObject playerSprint;
    public GameObject Chaser1;
    public GameObject Chaser2;
    public GameObject Chaser3;
    public GameObject Chaser4;
    public GameObject Mannequin;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            // Activa el MeshRenderer del hijo
            meshObject.SetActive(true);
            player.SetActive(false);
            Destroy(Chaser1);
            Destroy(Chaser2);
            Destroy(Chaser3);
            Destroy(Chaser4);
            Destroy(Mannequin);

            // Activa el AudioSource para la m�sica
            audioSource.Play();

            // Activa la animaci�n "cinem�tica"
            cinematicAnimator.SetTrigger("PlayCinematic");

            // Inicia una corrutina para activar el enemigo despu�s del retraso
            StartCoroutine(ActivateEnemyAfterDelay());

            triggered = true;
        }
    }

    private IEnumerator ActivateEnemyAfterDelay()
    {
        yield return new WaitForSeconds(activationDelay);
        playerSprint.SetActive(true);
        // Llama a la funci�n ActivateEnemy en el script del enemigo
        enemy.GetComponent<ChaserF>().ActivateEnemy();
    }
}
