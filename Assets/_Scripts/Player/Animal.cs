using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal 
{
    public abstract void MakeSound();

    public void Move()
    {
        Debug.Log("Animal is moving!");
    }
}
