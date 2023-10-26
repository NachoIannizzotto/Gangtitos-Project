using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class Lock : MonoBehaviour, IInteractable
{
    public bool lockOpen = false;

    public GameObject door;
    public static int unlockedLocks = 0;

    public bool Interact()
    {
        if (!lockOpen)
        {
            // Verificar si el jugador tiene al menos una llave
            if (CollectableCounter.instance != null && CollectableCounter.instance.GetCurrentCount() > 0)
            {
                StartCoroutine(OpenLock());
                lockOpen = true;
                unlockedLocks++;

                if (unlockedLocks >= 4)
                {
                    OpenDoor();
                }

                // Restar una llave del contador
                CollectableCounter.instance.RemoveFromCount();

                return true;
            }
            else
            {
                // El jugador no tiene llaves, no hacer nada
                return false;
            }
        }

        return false;
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.SetActive(false);
        }
    }

    IEnumerator OpenLock()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

