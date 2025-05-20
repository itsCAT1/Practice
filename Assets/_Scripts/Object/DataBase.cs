using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfor
{
    public string name;
    public int level;
    public int hp;
    public int dmg;
}

[Serializable]
public class DataBase
{
    public List<PlayerInfor> lists = new List<PlayerInfor>();
}
