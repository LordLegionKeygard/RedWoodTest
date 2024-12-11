using UnityEngine;

public class PlayerStateChanger : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }

    public PlayerState IdleState { get; private set; }
    public PlayerState MoveState { get; private set; }
    // public PlayerState AttackState { get; private set; }
    // public PlayerState MoveAttackState { get; private set; }

    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();

        IdleState = new IdleState(this, _playerMovement, _playerAnimator);
        MoveState = new MoveState(this, _playerMovement, _playerAnimator);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    public void ChangeState(PlayerState newState)
    {
        if (CurrentState != null) CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }

    private void Update()
    {
        CurrentState.HandleInput();
        CurrentState.UpdateLogic();
    }
}
