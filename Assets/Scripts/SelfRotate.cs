using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    private static float rotateSpeedMin = 15;
    private static float rotateSpeedMax = 35;

    private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(rotateSpeedMin, rotateSpeedMax); 
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        transform.Rotate(rotateSpeed * dt, rotateSpeed * dt, rotateSpeed * dt); 
    }
}
