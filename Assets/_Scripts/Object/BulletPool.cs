using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] List<GameObject> _listBullets;


    public GameObject getBullet()
    {
        foreach (var bullet in _listBullets)
        {
            if(bullet.activeSelf)
            {
                continue;
            }

            return bullet;
        }

        var bulletTemp = Instantiate(_bulletPrefab, this.transform.position, this.transform.rotation);
        _listBullets.Add(bulletTemp);
        return bulletTemp;
    }
}
