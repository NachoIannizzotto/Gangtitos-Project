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

    public AudioSource customAudioSource;
    public AudioClip[] soundClips;
    public float minTimeBetweenSounds = 10.0f;
    public float maxTimeBetweenSounds = 20.0f;

    private float nextSoundTime;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerFOV = GetComponent <PlayerFOV>();

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

        if (Time.time >= nextSoundTime)
        {
            PlayRandomSound(customAudioSource);
            nextSoundTime = Time.time + Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds);
        }
    }

    void PlayRandomSound(AudioSource audioSource)
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
        VHSManager.instance.DestroyVHS();
        SceneManager.LoadScene(deathScene);
    }
}

