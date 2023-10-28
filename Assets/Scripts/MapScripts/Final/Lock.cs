using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class Lock : MonoBehaviour, IInteractable
{
    public bool lockOpen = false;

    public GameObject door;
    public static int unlockedLocks = 0;
    public AudioSource doorSource;

    private ResetLocksManager gameManager;

    private Rigidbody rb; // Agrega un componente Rigidbody al GameObject del candado.
    public float minForce = 1.0f;
    public float maxForce = 3.0f;

    void Awake()
    {
        gameManager = FindObjectOfType<ResetLocksManager>();
        if (gameManager == null)
        {
            Debug.LogError("No se encontró un objeto ResetLocksManager en la escena.");
        }
        else
        {
            gameManager.ResetLocks();
        }

        rb = GetComponent<Rigidbody>(); // Obtén el componente Rigidbody del candado.
        rb.isKinematic = true; // Inicialmente, el candado no reacciona a la física.
    }

    public bool Interact()
    {
        if (!lockOpen)
        {
            if (CollectableCounter.instance != null && CollectableCounter.instance.GetCurrentCount() > 0)
            {
                lockOpen = true;
                gameManager.unlockedLocks++;

                if (gameManager.unlockedLocks == 5)
                {
                    OpenDoor();
                }

                CollectableCounter.instance.RemoveFromCount();

                rb.isKinematic = false; // Activa la física del candado.
                rb.useGravity = true; // Activa la gravedad para que el candado caiga.

                Vector3 randomForce = new Vector3(Random.Range(-maxForce, maxForce), Random.Range(minForce, maxForce), Random.Range(-maxForce, maxForce));
                rb.AddForce(randomForce, ForceMode.Impulse);


                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    void OpenDoor()
    {
        if (door != null)
        {
            doorSource.Play();
            door.SetActive(false);
        }
    }
}


