using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public string nextLevelName; // Nombre de la siguiente escena

    void Update()
    {
        // Detecta si se presiona la tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Carga la siguiente escena
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // Aseg�rate de que el nombre de la siguiente escena est� configurado en el Inspector
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogWarning("El nombre de la siguiente escena no est� configurado en el Inspector.");
        }
    }
}





