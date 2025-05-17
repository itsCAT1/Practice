using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Experimental.GraphView.GraphView;
using Unity.VisualScripting;

public class EnemyFilter : MonoBehaviour
{
    public List<GameObject> enemies;
    public Transform playerPos;

    void Start()
    {
        //FindObject();
        //SortByDistance();
        //FirstTarget();
        //SelectTarget();
        CheckTarget();
    }

    void FindObject()
    {
        var duckFly = enemies.Where(df => df.CompareTag("DuckFly"));

        foreach(var df in duckFly)
        {
            Debug.Log(df.name);
        }
    }

    void SortByDistance()
    {
        var sorted = enemies.OrderBy(enemy => Vector3.Distance(playerPos.transform.position, enemy.transform.position));

        foreach(var enemy in sorted)
        {
            Debug.Log(enemy.name);
        }
    }

    void FirstTarget()
    {
        var first = enemies.FirstOrDefault(df => df.CompareTag("Animal"));


        Debug.Log(first.name);
    }

    void SelectTarget()
    {
        var select = enemies.Select(t => t.name);

        foreach(var target in select)
        {
            Debug.Log(target);
        }
    }

    void CheckTarget()
    {
        var enemyActive = enemies.Where(e => e.activeSelf);

        foreach (var enemy in enemyActive)
        {
            Debug.Log(enemy.name);
        }

        if (enemies.Any(e => !e.activeSelf))
        {
            Debug.Log("Have enemy are deactived");
        }
    }
}
