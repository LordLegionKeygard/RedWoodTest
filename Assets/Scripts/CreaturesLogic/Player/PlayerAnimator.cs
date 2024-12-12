using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Transform _playerSpriteTransform;
    [SerializeField] private Animator _animator;
    private PlayerMovement _playerMovement;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float speed = _playerMovement.CurrentDirection.magnitude * _playerMovement.GetMoveSpeed();
        _animator.SetFloat(AnimatorStrings.Speed, speed, 0, Time.deltaTime);
    }

    public void SetBoolAnimation(int animation, bool state)
    {
        _animator.SetBool(animation, state);
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction.x > 0 && !_isFacingRight) Flip();
        else if (direction.x < 0 && _isFacingRight) Flip();
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _playerSpriteTransform.Rotate(0f, 180f, 0f);
    }
}
