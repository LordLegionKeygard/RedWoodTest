using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    [Inject] PlayerHealth _playerHealth;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private float _speed;
    private EnemyInformation _enemyInformation;
    private Rigidbody2D _rigidBody;
    private Vector2 _nextPoint;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _enemyInformation = GetComponent<EnemyInformation>();
    }

    private void Start()
    {
        SetupSpeed();
    }

    private void SetupSpeed()
    {
        _speed = _enemyInformation.GetEnemyInfo().Speed;
    }

    private void FixedUpdate()
    {
        _nextPoint = Vector2.right * _speed * Time.fixedDeltaTime;

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        float distance = DistanceToPlayer();

        if (distance < 0) _nextPoint.x *= -1;

        _spriteRenderer.flipX = distance < 0.2f;

        _rigidBody.MovePosition((Vector2)transform.position + _nextPoint);
    }

    private float DistanceToPlayer() { return _playerHealth.transform.position.x - transform.position.x; }
}