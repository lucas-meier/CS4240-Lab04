using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAttachment : MonoBehaviour
{
    private GameObject attachingObj = null;
    private bool firstPortal;
    private string portalLayer;
    // Start is called before the first frame update
    void Start()
    {
        firstPortal = GameManager.instance.portalInfos.portal1 == gameObject;
        portalLayer = "Portal" + (firstPortal ? "1" : "2"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attach(GameObject obj)
    {
        Detach();
        attachingObj = obj;
        attachingObj.layer = LayerMask.NameToLayer(portalLayer);
        // Debug.Log("set " + attachingObj.name + " layer to " + attachingObj.layer);
    }

    private void Detach()
    {
        if (attachingObj == null) return;
        attachingObj.layer = LayerMask.NameToLayer("Default");
    }
}
