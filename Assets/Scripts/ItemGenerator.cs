using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static ItemGenerator instance;
    public Bounds boundary;
    [Serializable]
    public class ItemConfig
    {
        public GameObject prefab;
        public int maxNum;
    }

    public List<ItemConfig> itemConfigs;
    public float recheckInterval;

    private Dictionary<GameObject, List<GameObject>> itemDict;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        itemDict = new Dictionary<GameObject, List<GameObject>>();
        StartCoroutine(Generate());
        foreach (var config in itemConfigs)
        {
            itemDict[config.prefab] = new List<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            foreach (var config in itemConfigs)
            {
                if (itemDict[config.prefab].Count < config.maxNum)
                {
                    SpawnOne(config.prefab);
                }
            }
            yield return new WaitForSeconds(recheckInterval);
        }
    }

    void SpawnOne(GameObject prefab)
    {
        var spawnee = Instantiate(prefab);
        itemDict[prefab].Add(spawnee);
        Vector3 spawnPos;
        do
        {
            spawnPos = new Vector3(
            UnityEngine.Random.Range(boundary.min.x, boundary.max.x),
            UnityEngine.Random.Range(boundary.min.y, boundary.max.y),
            UnityEngine.Random.Range(boundary.min.z, boundary.max.z)
            );
        }
        while (Physics.CheckBox(spawnPos, prefab.GetComponent<Collider>().bounds.extents + new Vector3(0.5f, 0.5f, 0.5f)));
            
        spawnee.transform.position = spawnPos;

        spawnee.GetComponent<OnDestroySubject>().AddObserve((Observer.OnDestroyInfo tmp) =>
        {
            itemDict[prefab].Remove(spawnee);
        });
    }
}
