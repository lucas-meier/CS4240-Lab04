using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject: MonoBehaviour
{
    public delegate void Issue();
    private Issue issue;
    public void AddObserve(Issue i)
    {
        issue += i;
    }

    public void RemoveObserve(Issue i)
    {
        issue -= i;
    }

    public void Publish()
    {
        issue();
    }
}
