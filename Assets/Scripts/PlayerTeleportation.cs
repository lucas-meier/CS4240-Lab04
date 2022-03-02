using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    [SerializeField]
    private GameObject leftHand;

    [SerializeField]
    private OVRInput.Button toggleButton;
    [SerializeField]
    private GameObject destinationIndicator;
    [SerializeField]
    private Material validMaterial, invalidMaterial;

    private CharacterController player;

    private Vector3 teleportDestination;

    enum TeleportDestinationStatus
    {
        Hidden,
        NotFound,
        InValid,
        Valid,
    }

    private TeleportDestinationStatus indicatorStatus = TeleportDestinationStatus.Hidden;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(toggleButton) == true)
        {
            SelectTeleportLocation();
        }
        else if (OVRInput.GetUp(toggleButton) == true)
        {
            if (indicatorStatus == TeleportDestinationStatus.Valid)
            {
                Teleport();
            }
            indicatorStatus = TeleportDestinationStatus.Hidden;
        }
        ShowIndicator();
    }

    private void ShowIndicator()
    {
        if (indicatorStatus == TeleportDestinationStatus.Valid || indicatorStatus == TeleportDestinationStatus.InValid)
        {
            destinationIndicator.SetActive(true);
            destinationIndicator.transform.position = teleportDestination;
            var renderer = destinationIndicator.GetComponent<MeshRenderer>();
            renderer.material = indicatorStatus == TeleportDestinationStatus.Valid ? validMaterial : invalidMaterial;
        }
        else if (indicatorStatus == TeleportDestinationStatus.Hidden || indicatorStatus == TeleportDestinationStatus.NotFound)
        {
            destinationIndicator.SetActive(false);
        }
    }

    void SelectTeleportLocation()
    {
        RaycastHit[] hits;

        //only reacts for ojects in the correct layer(s)
        hits = Physics.SphereCastAll(leftHand.transform.position, 0.5f, leftHand.transform.forward, Mathf.Infinity);

        if (hits.Length > 0)
        {
            int closeHit = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance < hits[closeHit].distance)
                {
                    closeHit = i;
                }
            }
            indicatorStatus = hits[closeHit].collider.gameObject.CompareTag("Floor") ? TeleportDestinationStatus.Valid : TeleportDestinationStatus.InValid;

            teleportDestination = hits[closeHit].point;
        }
        else
        {
            indicatorStatus = TeleportDestinationStatus.NotFound;
        }
    }

    void Teleport()
    {
        player.enabled = false;
        transform.position = teleportDestination;
        player.enabled = true;
    }
}
