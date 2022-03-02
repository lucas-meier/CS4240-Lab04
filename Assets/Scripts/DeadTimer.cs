using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTimer : MonoBehaviour
{
    public float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Eliminate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Eliminate()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
        yield return default;
    }

    private void OnDestroy()
    {
        var subject = GetComponent<Subject>();
        subject.Publish();
    }
}
