using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLocksManager : MonoBehaviour
{
    // Patr�n Singleton
    public static ResetLocksManager Instance { get; private set; }

    // Variable para rastrear el n�mero de candados desbloqueados
    public int unlockedLocks = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Esto asegura que el objeto persista entre las escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    // M�todo para reiniciar los candados
    public void ResetLocks()
    {
        unlockedLocks = 0;
    }
}