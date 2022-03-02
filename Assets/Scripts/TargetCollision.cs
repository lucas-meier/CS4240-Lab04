using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetCollision : MonoBehaviour, ISubject<int>
{
    ISubject<int>.Issue issue;
    [SerializeField]
    private int targetScore;

    [SerializeField]
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        AddObserve(scoreText.GetComponent<IObserver<int>>().Response);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Publish();
        }
    }
    public void AddObserve(ISubject<int>.Issue i)
    {
        issue += i;
    }

    public void RemoveObserve(ISubject<int>.Issue i)
    {
        issue -= i;
    }

    public void Publish()
    {
        issue(targetScore);
    }
}
