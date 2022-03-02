using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IObserver 
{
    [SerializeField]
    private OVRInput.Button button;
    public GameObject projectile;
    [SerializeField]
    private float speed;

    private bool shooted = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button) == true && !shooted && projectile != null)
        {
            Spawn();
        }
    }


    void Spawn()
    {
        var spawnee = Instantiate(projectile);
        spawnee.transform.position = transform.position;
        spawnee.transform.rotation = transform.rotation;
        Debug.Log(transform.position + " " + transform.rotation);
        var rb = spawnee.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        var subject = spawnee.GetComponent<Subject>();
        subject.AddObserve(Response);
        shooted = true;
    }

    public void Response()
    {
        shooted = false;
    }
}
