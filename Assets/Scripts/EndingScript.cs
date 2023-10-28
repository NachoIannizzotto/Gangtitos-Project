using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public string scene1;

    public void LoadSceneOnClick1()
    {
        MusicManager.instance.DestroyMusicManager();
        SceneManager.LoadScene(scene1);
    }
}