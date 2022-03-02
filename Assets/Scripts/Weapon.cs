using Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IObserver<Observer.OnPickedInfo>
{
    [SerializeField]
    private int totalAmmo;
    public int currentAmmo;

    [SerializeField]
    private Vector3 localPositionMax, localPositionMin;

    public List<string> pickableItems;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Redraw()
    {
        float percentage = (float)currentAmmo / totalAmmo;
        transform.localPosition = localPositionMax * percentage + (1 - percentage) * localPositionMin;
        transform.localScale = new Vector3(transform.localScale.x, percentage, transform.localScale.z);
    }

    public void Response(OnPickedInfo t)
    {
        if (pickableItems.Contains(t.name))
        {
            int deltaAmmo = t.score;
            currentAmmo += deltaAmmo;
            currentAmmo = Mathf.Clamp(currentAmmo, 0, totalAmmo);
            Redraw();
        }
    }

}
