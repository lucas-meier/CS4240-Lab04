using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour, ISubject<Observer.OnPickedInfo>
{
    [SerializeField]
    private OVRInput.Button button;
    public GameObject projectile;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Observer.OnPickedInfo onPickedInfo;

    private ISubject<Observer.OnPickedInfo>.Issue shootedIssue;
    private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        var observers = FindObjectsOfType<MonoBehaviour>().OfType<IObserver<Observer.OnPickedInfo>>();
        foreach (var observer in observers)
        {
            AddObserve(observer.Response);
        }
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button) == true && projectile != null)
        {
            if (weapon.currentAmmo > 0)
            {
                Spawn();
                Publish();
            }
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

    public void AddObserve(ISubject<Observer.OnPickedInfo>.Issue i)
    {
        shootedIssue += i;
    }

    public void RemoveObserve(ISubject<Observer.OnPickedInfo>.Issue i)
    {
        shootedIssue -= i;
    }

    public void Publish()
    {
        shootedIssue(onPickedInfo);
    }
}
