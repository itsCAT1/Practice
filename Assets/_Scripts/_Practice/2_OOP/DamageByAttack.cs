using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DamageByAttack
{
    public void TakeDamage(int damage);
}

public interface DamageByMagic
{
    public void TakeDamage(int damage);
}