using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string scene1;
    public string scene2;

    public void LoadSceneOnClick1()
    {
        SceneManager.LoadScene(scene1);
    }

    public void LoadSceneOnClick2()
    {
        SceneManager.LoadScene(scene2);
    }
}
