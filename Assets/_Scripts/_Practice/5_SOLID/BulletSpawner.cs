using UnityEngine;

public class BulletSpawner
{
    private Transform spawnPoint;

    public BulletSpawner(Transform point)
    {
        spawnPoint = point;
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPoolingExample.Instance.GetBullet();
        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = spawnPoint.rotation;
        bullet.SetActive(true);
    }
}
