using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private bool firstCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var otherPortal = firstCamera ? GameManager.instance.portalInfos.portal2 : GameManager.instance.portalInfos.portal1;
        var thisPortal = firstCamera ? GameManager.instance.portalInfos.portal1 : GameManager.instance.portalInfos.portal2;
        if (otherPortal != null && thisPortal != null)
        {
            var vec = thisPortal.transform.position - GameManager.instance.PlayerPosition();
            var rot = thisPortal.transform.rotation * Quaternion.Inverse(otherPortal.transform.rotation);
            vec = rot * vec;
            transform.position = new Vector3(
                otherPortal.transform.position.x - vec.x,
                otherPortal.transform.position.y,
                otherPortal.transform.position.z - vec.z
                );
            transform.LookAt(otherPortal.transform);
            transform.position = new Vector3(
                otherPortal.transform.position.x - vec.x,
                otherPortal.transform.position.y + vec.y,
                otherPortal.transform.position.z - vec.z
                );
        }
    }
}
