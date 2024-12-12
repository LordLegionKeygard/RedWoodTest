using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 1;
    private float _speed = 20f;
    private float _lifetime = 2f;
    private float _timer;
    private Rigidbody2D _rigidBody;
    private BulletPool pool;

    public void Initialize(BulletPool pool)
    {
        this.pool = pool;
    }

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
        _rigidBody.velocity = Vector2.zero;
        if (pool != null)
        {
            pool.ReturnBullet(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
