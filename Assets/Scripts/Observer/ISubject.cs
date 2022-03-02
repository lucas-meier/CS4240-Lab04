using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T">deleget type for in param</typeparam>
public interface ISubject<T>
{
    public delegate void Issue(T t);
    public void AddObserve(Issue i);
    public void RemoveObserve(Issue i);
    public void Publish();
}
