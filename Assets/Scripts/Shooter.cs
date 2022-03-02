using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Button button;
    public GameObject projectile;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button) == true && projectile != null)
        {
            Spawn();
        }
    }


    void Spawn()
    {
        var spawnee = Instantiate(projectile);
        spawnee.transform.position = transform.position;
        spawnee.transform.rotation = transform.rotation;
        var rb = spawnee.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }
}
