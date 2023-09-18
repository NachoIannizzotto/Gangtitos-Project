using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpot : MonoBehaviour
{
    //public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer, PlayerCam, HidePlayerCam;
    public EnemyChase monsterScript;
    public Transform monsterTransform;
    bool interactable, hiding;
    public float loseDistance;
    public roomDetector detector;

    void Start()
    {
        interactable = false;
        hiding = false;
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PlayerCamera"))
        {
            if(detector.inTrigger == true)
            {
                //hideText.SetActive(true);
                interactable = true;
            }
            else if(detector.inTrigger == false)
            {
                //hideText.SetActive(false);
                interactable = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerCamera"))
        {
            //hideText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //hideText.SetActive(false);
                hidingPlayer.SetActive(true);
                HidePlayerCam.SetActive(true);
                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if(distance > loseDistance)
                {
                    if(monsterScript.chasing == true)
                    {
                        monsterScript.stopChase();
                    }
                }
                //stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                PlayerCam.SetActive(false);
                interactable = false;
            }
        }
        if(hiding == true)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                //stopHideText.SetActive(false);
                normalPlayer.SetActive(true);
                PlayerCam.SetActive(true);
                HidePlayerCam.SetActive(false);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}
