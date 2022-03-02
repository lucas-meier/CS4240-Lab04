using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IObserver<T>
{
    public void Response(T t);
}

interface IObserver
{
    public void Response();
}
