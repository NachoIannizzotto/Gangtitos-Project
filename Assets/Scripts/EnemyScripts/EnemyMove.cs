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

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerFOV = GetComponent<PlayerFOV>();
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
    }

    IEnumerator deathRoutine()
    {
        jumpscareCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(jumpscareTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(deathScene);
    }
}