public abstract class PlayerState
{
    protected PlayerStateChanger _stateChanger;
    protected PlayerMovement _playerMovement;
    protected PlayerAnimator _playerAnimator;
    protected PlayerAmmoSystem _playerAmmoSystem;

    public PlayerState(PlayerStateChanger stateChanger, PlayerMovement movement, PlayerAnimator animator, PlayerAmmoSystem playerAmmoSystem)
    {
        _stateChanger = stateChanger;
        _playerMovement = movement;
        _playerAnimator = animator;
        _playerAmmoSystem = playerAmmoSystem;
    }

    public virtual void Enter() {}
    public virtual void HandleInput() {}
    public virtual void UpdateLogic() {}
    public virtual void Exit() {}
}
