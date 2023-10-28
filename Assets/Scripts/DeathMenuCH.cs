using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuCH : MonoBehaviour
{
    public string scene1;
    public string scene2;
    public string scene3;

    public void LoadSceneOnClick11()
    {
        SceneManager.LoadScene(scene1);
    }

    public void LoadSceneOnClick22()
    {
        SceneManager.LoadScene(scene2);
    }

    public void LoadSceneOnClick33()
    {
        SceneManager.LoadScene(scene3);
    }
}
