using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToAnotherLevel : MonoBehaviour
{
    public string levelToLoad;
    public AudioClip newMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MusicManager.instance.PlayMusic(newMusic);
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
