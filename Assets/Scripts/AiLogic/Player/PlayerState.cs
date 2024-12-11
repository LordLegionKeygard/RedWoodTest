public abstract class PlayerState
{
    protected PlayerStateChanger _stateChanger;
    protected PlayerMovement _playerMovement;
    protected PlayerAnimator _playerAnimator;

    public PlayerState(PlayerStateChanger stateChanger, PlayerMovement movement, PlayerAnimator animator)
    {
        _stateChanger = stateChanger;
        _playerMovement = movement;
        _playerAnimator = animator;
    }

    public virtual void Enter() {}
    public virtual void HandleInput() {}
    public virtual void UpdateLogic() {}
    public virtual void UpdatePhysics() {}
    public virtual void Exit() {}
}
