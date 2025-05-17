using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    public delegate void Saysomething(string message);

    public Saysomething say;

    void Start()
    {
        say = Hello;

        say += Using;
    }

    void Hello(string message)
    {
        Debug.Log("Hello Delegate " + message);
    }

    void Using(string message)
    {
        Debug.Log("Using Delegate " + message);
    }
}
