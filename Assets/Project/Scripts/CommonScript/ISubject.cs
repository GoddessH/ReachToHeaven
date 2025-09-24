using System;
using UnityEngine;

public interface ISubject<T> where T : Delegate
{
    //
    public void Subscribe(T subscriber);
    public void UnSubscribe(T subscriber);
}
