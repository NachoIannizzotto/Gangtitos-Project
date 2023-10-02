using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    public Camera cameraMain;
    Plane[] cameraFrustum;
    Collider colliderMain;
    public LayerMask enemyLayer;
    public float fieldOfView = 90.0f;
    public Animator aiAnim;

    public bool canSeeEnemy = false;

    public void Start()
    {
        colliderMain = GetComponent<Collider>();
    }

    private void Update()
    {
        canSeeEnemy = false;
        aiAnim.speed = 1.0f;

        Vector3 playerPosition = transform.position;
        Vector3 directionToPlayer = playerPosition - cameraMain.transform.position;
        float angle = Vector3.Angle(directionToPlayer, cameraMain.transform.forward);

        if (angle <= fieldOfView * 0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(cameraMain.transform.position, directionToPlayer, out hit, Mathf.Infinity, enemyLayer))
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
                {
                    canSeeEnemy = true;
                    aiAnim.speed = 0.0f;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cameraMain.transform.position, transform.position - cameraMain.transform.position);
    }
}


