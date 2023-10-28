using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaserF : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isActive = false;
    public string deathScene;
    public Camera jumpscareCamera;
    public Animator aiAnim;
    public float jumpscareTime;

    private void FixedUpdate()
    {
        if (isActive)
        {
            aiAnim.SetTrigger("sprint");
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void ActivateEnemy()
    {
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        aiAnim.SetTrigger("jumpscare");
        StartCoroutine(deathRoutine());
    }

    IEnumerator deathRoutine()
    {
        jumpscareCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(jumpscareTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MusicManager.instance.DestroyMusicManager();
        SceneManager.LoadScene(deathScene);
    }
}



