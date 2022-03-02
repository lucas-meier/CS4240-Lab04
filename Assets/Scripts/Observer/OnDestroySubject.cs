using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Observer
{
    [Serializable]
    public class OnDestroyInfo
    {

    };
}

public class OnDestroySubject : MonoBehaviour, ISubject<Observer.OnDestroyInfo>
{
    [SerializeField]
    private Observer.OnDestroyInfo onDestroyInfo;
    ISubject<Observer.OnDestroyInfo>.Issue issue;
    public void AddObserve(ISubject<Observer.OnDestroyInfo>.Issue i)
    {
        issue += i;
    }

    public void Publish()
    {
        issue(onDestroyInfo);
    }

    public void RemoveObserve(ISubject<Observer.OnDestroyInfo>.Issue i)
    {
        issue -= i;
    }

    // Start is called before the first frame update
    void Start()
    {
        var observers = FindObjectsOfType<MonoBehaviour>().OfType<IObserver<Observer.OnDestroyInfo>>();
        foreach (var observer in observers)
        {
            AddObserve(observer.Response);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Publish();
    }
}
