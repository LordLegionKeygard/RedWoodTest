using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidBody;
    public Vector2 CurrentDirection { get; private set; }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovementInput();
    }

    public void HandleMovementInput()
    {
        float horizontal = Input.GetAxis(WorldGameInfo.HorizontalAxis);
        float vertical = Input.GetAxis(WorldGameInfo.VerticalAxis);

        CurrentDirection = new Vector2(horizontal, vertical).normalized;

        if (CurrentDirection != Vector2.zero) Move(CurrentDirection);
    }

    private void Move(Vector2 direction)
    {
        Vector2 movement = CurrentDirection * _moveSpeed * Time.fixedDeltaTime;
        _rigidBody.MovePosition(_rigidBody.position + movement);
    }
}
