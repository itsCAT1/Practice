using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    public override void Dead()
    {
        Debug.Log("Enemy is DEAD");
    }
}
