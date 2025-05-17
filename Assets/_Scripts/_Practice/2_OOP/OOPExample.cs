using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string enemyName;
    private int exp;

    public virtual void Attack()
    {
        enemyName = "enemy ";
        Debug.Log(enemyName + "attack");
    }

    public void Attack(int times)
    {
        Debug.Log(enemyName + "attack in " + times);
    }

    public void Attack(int times, string type)
    {
        Debug.Log(enemyName + "attack in " + times + " by " + type);
    }
}

public class Troll : Enemy
{
    public override void Attack()
    {
        base.Attack();

        Debug.Log(enemyName + "deal damage");
    }

    public void Jump()
    {
        Debug.Log(enemyName + "jump");
    }
}

public class Dragon : Enemy
{
    public override void Attack()
    {
        enemyName = "dragon ";
        Debug.Log(enemyName + "deal damage");
    }

    public void Fly()
    {
        Debug.Log(enemyName + "fly");
    }
}

public class OOPExample : MonoBehaviour
{
    public void Start()
    {
        Troll troll = new Troll();
        troll.enemyName = "troll ";
        troll.Attack();
        troll.Attack(2);
        troll.Attack(3, "magic");
        troll.Jump();

        /*Dragon dragon = new Dragon();
        troll.enemyName = "dragon ";
        dragon.Attack();
        dragon.Fly();*/
    }
}
