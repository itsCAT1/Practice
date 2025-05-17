using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damageable
{

    public override void Dead()
    {
        Debug.Log("Player is DEAD");
    }
}
