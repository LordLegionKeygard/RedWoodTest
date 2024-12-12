using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(PlayerStateChanger stateChanger, PlayerMovement movement, PlayerAnimator animator) : base(stateChanger, movement, animator)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, false);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _playerAnimator.SetDirection(_playerMovement.CurrentDirection);

        if (_playerMovement.CurrentDirection == Vector2.zero)
        {
            _stateChanger.ChangeState(_stateChanger.IdleState);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _stateChanger.ChangeState(_stateChanger.AttackState);
        }
    }
}
