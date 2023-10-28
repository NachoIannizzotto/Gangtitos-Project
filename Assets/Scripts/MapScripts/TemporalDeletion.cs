using System.Collections;
using UnityEngine;

public class TemporalDeletion : MonoBehaviour
{
    public GameObject tempObject;
    public float waitTime = 5.0f;

    private void Start()
    {
        StartCoroutine(DeleteObjectAfterWait());
    }

    private IEnumerator DeleteObjectAfterWait()
    {
        yield return new WaitForSeconds(waitTime);

        if (tempObject != null)
        {
            Destroy(tempObject);
        }
    }
}

