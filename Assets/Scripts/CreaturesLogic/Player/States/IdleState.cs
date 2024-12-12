using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerStateChanger controller, PlayerMovement movement, PlayerAnimator animator) : base(controller, movement, animator)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter - IdleState");
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, false);
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (_playerMovement.CurrentDirection != Vector2.zero)
        {
            _stateChanger.ChangeState(_stateChanger.MoveState);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _stateChanger.ChangeState(_stateChanger.AttackState);
        }
    }
}
