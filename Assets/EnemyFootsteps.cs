using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootsteps : MonoBehaviour
{
    [SerializeField] private Transform player;
    public AudioClip[] footstepClips;
    public float minTimeBetweenFootsteps = 1.0f;
    public float maxTimeBetweenFootsteps = 2.0f;

    private AudioSource audioSource;
    private PlayerFOV playerFOV;
    private float nextFootstepTime;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerFOV = player.GetComponent<PlayerFOV>(); // Obtén el PlayerFOV del jugador.
        nextFootstepTime = Time.time + Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (!playerFOV.canSeeEnemy && distanceToPlayer < 8)
        {
            if (Time.time >= nextFootstepTime)
            {
                PlayRandomFootstepSound();
                nextFootstepTime = Time.time + Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps);
            }
        }
    }

    private void PlayRandomFootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepClips.Length);
            audioSource.clip = footstepClips[randomIndex];
            audioSource.Play();
        }
    }
}

