using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewParty : MonoBehaviour
{
    public void LoadScene()
    {
        StartCoroutine("start");
    }

    public IEnumerator start()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("TestLevel");
    }
}