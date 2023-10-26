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
    }

    public bool Interact()
    {
        if (!lockOpen)
        {
            if (CollectableCounter.instance != null && CollectableCounter.instance.GetCurrentCount() > 0)
            {
                StartCoroutine(OpenLock());
                lockOpen = true;
                gameManager.unlockedLocks++;

                if (gameManager.unlockedLocks == 4)
                {
                    OpenDoor();
                }

                CollectableCounter.instance.RemoveFromCount();

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

    IEnumerator OpenLock()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

