using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField]
    private OVRInput.Button button;

    private Rigidbody rb;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button) == true)
        {
            rb.AddForce(new Vector3(0, 0, 1) * speed);
        }
    }
}
