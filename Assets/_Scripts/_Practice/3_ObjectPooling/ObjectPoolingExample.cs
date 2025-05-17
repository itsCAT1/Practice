using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingExample : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<GameObject> bulletList;

    private static ObjectPoolingExample _instance;
    public static ObjectPoolingExample Instance
    {
        get
        {
            if (_instance == null) Debug.Log("Bullet is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        else
        {
            Destroy(_instance.gameObject);
        }
    }

    public GameObject GetBullet()
    {
        foreach (var bullet in bulletList)
        {
            if (bullet.activeSelf)
            {
                continue;
            }
            return bullet;
        }

        var bulletTemp = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bulletList.Add(bulletTemp);
        return bulletTemp;
    }
}
