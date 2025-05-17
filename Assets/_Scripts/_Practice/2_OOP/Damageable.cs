using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;

        health -= damage;

        if (health <= 0) Dead();
    }


    public abstract void Dead();
}
