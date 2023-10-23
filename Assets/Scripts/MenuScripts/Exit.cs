using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitApp()
    {
        StartCoroutine("button_exit");
    }

    public IEnumerator button_exit()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
