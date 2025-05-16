using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Enemy
{
    public string name;
    public int level;
    public int hp;
    public int dmg;
}


[CreateAssetMenu(fileName = "SOExample", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ScriptableObjectExample : ScriptableObject
{
    public List<Enemy> enemies = new List<Enemy>();
}
