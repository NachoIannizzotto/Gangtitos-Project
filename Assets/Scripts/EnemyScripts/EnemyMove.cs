using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform Player;

    NavMeshAgent agent;
    PlayerFOV playerFOV;
    public Animator aiAnim;
    public string deathScene;
    public Camera jumpscareCamera;
    public float jumpscareTime;

    private AudioSource audioSource;
    public AudioClip[] soundClips;  // Arreglo de clips de sonido
    public float minTimeBetweenSounds = 10.0f;
    public float maxTimeBetweenSounds = 20.0f;

    private float nextSoundTime;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerFOV = GetComponent<PlayerFOV>();
        audioSource = GetComponent<AudioSource>();

        // Configura el tiempo inicial para reproducir un sonido.
        nextSoundTime = Time.time + Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
    }

    private void Update()
    {
        if (playerFOV.canSeeEnemy == false)
        {
            agent.SetDestination(Player.position);
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }

        float DistanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if (DistanceToPlayer < 2 && playerFOV.canSeeEnemy == false)
        {
            aiAnim.SetTrigger("jumpscare");
            StartCoroutine(deathRoutine());
        }

        // Reproduce un sonido si ha pasado el tiempo para hacerlo.
        if (Time.time >= nextSoundTime)
        {
            PlayRandomSound();
            // Configura el próximo tiempo de reproducción de sonido.
            nextSoundTime = Time.time + Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
        }
    }

    void PlayRandomSound()
    {
        if (soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length);
            audioSource.clip = soundClips[randomIndex];
            audioSource.Play();
        }
    }

    IEnumerator deathRoutine()
    {
        playerFOV.enabled = false;
        jumpscareCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(jumpscareTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MusicManager.instance.DestroyMusicManager();
        SceneManager.LoadScene(deathScene);
    }
}
