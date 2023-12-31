using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, detectionDistance, catchDistance, searchDistance, minChaseTime, maxChaseTime, minSearchTime, maxSearchTime, jumpscareTime;
    public bool walking, chasing, searching;
    public Transform player;
    public Transform cam;
    Transform currentDest;
    Vector3 dest;
    public Vector3 rayCastOffset;
    public string deathScene;
    public Camera jumpscareCamera;
    public float aiDistance;

    void Start()
    {
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        aiDistance = Vector3.Distance(player.position, this.transform.position);
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, detectionDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("searchRoutine");
                StartCoroutine("searchRoutine");
                searching = true;
            }
        }
        if (searching == true)
        {
            ai.speed = 0;
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("sprint");
            aiAnim.SetTrigger("search");
            if(aiDistance <= searchDistance)
            {
                StopCoroutine("stayIdle");
                StopCoroutine("searchRoutine");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
                searching = false;
            }
        }
        if (chasing == true)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("search");
            aiAnim.SetTrigger("sprint");

            if (ai.hasPath)
            {
                if (!ai.pathPending && ai.remainingDistance <= catchDistance)
                {
                    player.gameObject.SetActive(false);
                    cam.gameObject.SetActive(false);
                    aiAnim.ResetTrigger("walk");
                    aiAnim.ResetTrigger("idle");
                    aiAnim.ResetTrigger("search");
                    aiAnim.ResetTrigger("sprint");
                    aiAnim.SetTrigger("jumpscare");
                    StartCoroutine(deathRoutine());
                    chasing = false;
                }
            }
            else
            {
                stopChase();
            }
        }
        if (walking == true)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("search");
            aiAnim.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("sprint");
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("search");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Color del rayo
        Vector3 raycastStart = transform.position + rayCastOffset;
        Vector3 rayDirection = (player.position - raycastStart).normalized;
        Gizmos.DrawRay(raycastStart, rayDirection * detectionDistance);
    }

    public void stopChase()
    {
        walking = true;
        chasing = false;
        StopCoroutine("chaseRoutine");
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator searchRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minSearchTime, maxSearchTime));
        searching = false;
        walking = true;
        currentDest = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator chaseRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minChaseTime, maxChaseTime));
        stopChase();
    }
    IEnumerator deathRoutine()
    {
        jumpscareCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(jumpscareTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MusicManager.instance.DestroyMusicManager();
        VHSManager.instance.DestroyVHS();
        SceneManager.LoadScene(deathScene);
    }
}