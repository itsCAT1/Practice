using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionExample : MonoBehaviour
{
    public Action<string> say;

    void Start()
    {
        say = Hello;
        say += Using;
    }

    void Hello(string message)
    {
        Debug.Log("Hello Action " + message);
    }

    void Using(string message)
    {
        Debug.Log("Using Action " + message);
    }
}
