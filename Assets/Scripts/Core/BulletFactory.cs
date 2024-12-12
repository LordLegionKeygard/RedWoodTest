using UnityEngine;

public class BulletFactory : IBulletFactory
{
    private BulletPool _bulletPool;

    public BulletFactory(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void CreateBullet(Transform firePoint)
    {
        var bullet = _bulletPool.GetBullet();
        bullet.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
    }
}
