using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Observer
{
    [Serializable]
    public class OnScoreUpdateInfo
    {
        public int score;
    }
}

public class TargetCollision : MonoBehaviour, ISubject<Observer.OnScoreUpdateInfo>
{
    ISubject<Observer.OnScoreUpdateInfo>.Issue issue;
    [SerializeField]
    private Observer.OnScoreUpdateInfo updateInfo;

    // Start is called before the first frame update
    void Start()
    {
        var observers = FindObjectsOfType<MonoBehaviour>().OfType<IObserver<Observer.OnScoreUpdateInfo>>();
        foreach (var observer in observers)
        {
            AddObserve(observer.Response);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            var thisRenderer = gameObject.GetComponent<MeshRenderer>();
            var otherRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            thisRenderer.material = otherRenderer.material;
            Publish();
            Destroy(otherRenderer.gameObject);
        }
    }
    public void AddObserve(ISubject<Observer.OnScoreUpdateInfo>.Issue i)
    {
        issue += i;
    }

    public void RemoveObserve(ISubject<Observer.OnScoreUpdateInfo>.Issue i)
    {
        issue -= i;
    }

    public void Publish()
    {
        issue(updateInfo);
    }
}
