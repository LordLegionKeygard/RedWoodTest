using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    public float GetMoveSpeed() => _moveSpeed;
    private Rigidbody2D _rigidBody;
    public Vector2 CurrentDirection { get; private set; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void FixedUpdate()
    {
        if (CurrentDirection == Vector2.zero)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.velocity = CurrentDirection * _moveSpeed;
        }
    }

    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxisRaw(WorldGameInfo.HorizontalAxis);
        float vertical = Input.GetAxisRaw(WorldGameInfo.VerticalAxis);

        CurrentDirection = new Vector2(horizontal, 0).normalized;
    }
}
