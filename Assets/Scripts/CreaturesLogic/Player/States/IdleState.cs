using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerStateChanger controller,
                    PlayerMovement movement,
                    PlayerAnimator animator,
                    PlayerAmmoSystem playerAmmoSystem)
                    : base(controller, movement, animator, playerAmmoSystem) { }

    public override void Enter()
    {
        base.Enter();
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, false);
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (_playerMovement.CurrentDirection != Vector2.zero)
        {
            _stateChanger.ChangeState(_stateChanger.MoveState);
        }
        if (Input.GetMouseButtonDown(0) && _playerAmmoSystem.HaveBullet())
        {
            _stateChanger.ChangeState(_stateChanger.AttackState);
        }
    }
}
