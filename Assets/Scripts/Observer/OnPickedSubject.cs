using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Observer
{
    [Serializable]
    public class OnPickedInfo
    {
        public string name;
        public int score;
    }
}

public class OnPickedSubject : MonoBehaviour, ISubject<Observer.OnPickedInfo>
{
    [SerializeField]
    private Observer.OnPickedInfo info;

    ISubject<Observer.OnPickedInfo>.Issue issue;

    public void AddObserve(ISubject<Observer.OnPickedInfo>.Issue i)
    {
        issue += i;
    }

    public void Publish()
    {
        issue(info);
    }

    public void RemoveObserve(ISubject<Observer.OnPickedInfo>.Issue i)
    {
        issue -= i;
    }

    // Start is called before the first frame update
    void Start()
    {
        var observers = FindObjectsOfType<MonoBehaviour>().OfType<IObserver<Observer.OnPickedInfo>>();
        foreach (var observer in observers)
        {
            AddObserve(observer.Response);
        }
        AddObserve((Observer.OnPickedInfo tmp) =>
        {
            Destroy(gameObject);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
