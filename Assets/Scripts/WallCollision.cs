using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    [SerializeField]
    bool firstPortalProjectile;

    private GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        portal = firstPortalProjectile ? GameManager.instance.portalInfos.portal1 : GameManager.instance.portalInfos.portal2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Wall")) return;
        portal.transform.position = transform.position;
        var vec1 = GameManager.instance.PlayerPosition() - other.gameObject.transform.position;
        var vec2 = other.gameObject.transform.forward;
        if (Vector3.Dot(vec1, vec2) < 0)
        {
            // Backside facing the player
            portal.transform.rotation = other.gameObject.transform.rotation;
            portal.transform.Rotate(0, 180, 0);
        }
        else // Frontside facing the player
        {
            portal.transform.rotation = other.gameObject.transform.rotation;
        }
        portal.GetComponent<PortalAttachment>().Attach(other.gameObject);
        Destroy(gameObject);
    }
}
