using UnityEngine;
using UnityEngine.AI;

public class EnemyFootsteps: MonoBehaviour
{
    public Transform player; // Arrastra el objeto del jugador aquí en el Inspector.
    public NavMeshAgent enemyAgent; // Asegúrate de que el enemigo tiene un componente NavMeshAgent asignado.

    public AudioSource footstepAudioSource; // Asigna el componente AudioSource para los sonidos de pasos en el Inspector.
    public AudioClip[] footstepSounds; // Array de sonidos de pasos.

    public float minDistanceToPlayer = 10f; // Define la distancia mínima para empezar a reproducir sonidos de pasos aleatorios.

    PlayerFOV playerFOV; // Referencia al script PlayerFOV.

    void Start()
    {
        // Accede al script PlayerFOV en el jugador.
        playerFOV = GetComponent<PlayerFOV>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Utiliza la variable canSeeEnemy del script PlayerFOV para verificar si el jugador puede ver al enemigo.
        if (!playerFOV.canSeeEnemy && distanceToPlayer < minDistanceToPlayer)
        {
            if (!footstepAudioSource.isPlaying)
            {
                int randomSoundIndex = Random.Range(0, footstepSounds.Length);
                footstepAudioSource.clip = footstepSounds[randomSoundIndex];
                footstepAudioSource.Play();
            }
        }
        else
        {
            footstepAudioSource.Stop();
        }
    }
}




