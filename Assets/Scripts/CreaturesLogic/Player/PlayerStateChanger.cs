using UnityEngine;
using Zenject;

public class PlayerStateChanger : MonoBehaviour
{
    [Inject] PlayerAmmoSystem _playerAmmoSystem;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 0.1f;
    [SerializeField] private BulletPool _bulletPool;

    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;
    private IBulletFactory _bulletFactory;
    private PlayerState _currentState;

    public PlayerState IdleState { get; private set; }
    public PlayerState MoveState { get; private set; }
    public PlayerState AttackState { get; private set; }

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();

        _bulletFactory = new BulletFactory(_bulletPool);

        IdleState = new IdleState(this, _playerMovement, _playerAnimator, _playerAmmoSystem);
        MoveState = new MoveState(this, _playerMovement, _playerAnimator, _playerAmmoSystem);
        AttackState = new AttackState(this, _playerMovement, _playerAnimator, _firePoint, _fireRate, _bulletFactory, _playerAmmoSystem);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    public void ChangeState(PlayerState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    private void Update()
    {
        _currentState.HandleInput();
        _currentState.UpdateLogic();
    }
}
