using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int HitRange = 5;

    [SerializeField] private LayerMask layerMaskInteract;

    [SerializeField] private string excludeLayerName = null;

    private DoorController raycasteObject;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    //[SerializeField] private Image crosshair = null;
    //private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";

    [SerializeField] private Transform playerCameraTransform;

    private ControllerUI cui;

    private RaycastHit hit;
    private void Start()
    {
        cui = FindObjectOfType<ControllerUI>();
    }

    private void Update()
    {
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, HitRange, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycasteObject = hit.collider.gameObject.GetComponent<DoorController>();
                    //CrossHairChange(true);
                }

                //isCrosshairActive = true;
                //doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycasteObject.PlayAnimation();
                }
            }
        }

        //else
        {
            //if (isCrosshairActive*)
            {
                //CrossHairChange(false);
                //doOnce = false;
            }
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, HitRange, layerMaskInteract))
        {
            cui.ActivateAndSetTextObject($"E");
        }
    }

    /*void CrossHairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.yellow;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }*/
}
