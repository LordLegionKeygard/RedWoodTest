using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 1;
    private float _speed = 25;
    private float _lifetime = 2;
    private float _timer;
    private Rigidbody2D _rigidBody;
    private BulletPool _pool;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _timer = _lifetime;
    }

    private void Update()
    {
        _rigidBody.velocity = transform.right * _speed;
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            ReturnToPool();
        }
    }

    public void SetPool(BulletPool pool)
    {
        _pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.TakeDamage(_damage);
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        _pool.ReturnBullet(gameObject);
    }
}
