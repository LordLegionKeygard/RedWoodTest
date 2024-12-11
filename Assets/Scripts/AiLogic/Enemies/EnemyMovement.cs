using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    [Inject] PlayerHealth _playerHealth;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isFacingRight = true;
    private Rigidbody2D _rigidBody;
    private Vector2 _nextPoint;
    public Transform Model;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _nextPoint = Vector2.right * _speed * Time.fixedDeltaTime;

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        float distance = DistanceToPlayer();

        if (distance < 0)
            _nextPoint.x *= -1;

        if (distance > 0.2f && !_isFacingRight)
            Flip();

        else if (distance < 0.2f && _isFacingRight)
            Flip();

        _rigidBody.MovePosition((Vector2)transform.position + _nextPoint);
    }

    public virtual float DistanceToPlayer() { return _playerHealth.transform.position.x - transform.position.x; }

    public virtual void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Model.Rotate(0f, 180f, 0f);
    }
}