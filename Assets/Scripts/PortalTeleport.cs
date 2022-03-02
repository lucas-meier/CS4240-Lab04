using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField]
    private bool firstPortal;
    [SerializeField]
    private float deltaForward = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var otherPortal = firstPortal ? GameManager.instance.portalInfos.portal2 : GameManager.instance.portalInfos.portal1;
        var thisPortal = firstPortal ? GameManager.instance.portalInfos.portal1 : GameManager.instance.portalInfos.portal2;
        if (otherPortal != null && thisPortal != null)
        {
            var rot = otherPortal.transform.rotation * Quaternion.Inverse(thisPortal.transform.rotation);
            TeleportPlayer(otherPortal.transform.position + otherPortal.transform.forward * deltaForward, rot);
        }
    }

    private void TeleportPlayer(Vector3 destPosition, Quaternion rotation) 
    {
        var playerRb = GameManager.instance.player.GetComponent<Rigidbody>();
        playerRb.position = destPosition;
        playerRb.rotation = rotation * GameManager.instance.player.transform.rotation;
    }
}
