using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _initialSize = 20;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    private void Awake()
    {
        Prewarm();
    }

    private void Prewarm()
    {
        for (int i = 0; i < _initialSize; i++)
        {
            var bullet = Instantiate(_bulletPrefab, transform);
            bullet.SetActive(false);
            bullet.transform.SetParent(transform);
            _pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (_pool.Count > 0)
        {
            var bullet = _pool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instantiate(_bulletPrefab, transform);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
        _pool.Enqueue(bullet);
    }
}
