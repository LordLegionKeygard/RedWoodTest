using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    private PlayerMovement _playerMovement;

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
        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
