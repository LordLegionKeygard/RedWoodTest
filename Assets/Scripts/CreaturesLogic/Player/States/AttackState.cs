using UnityEngine;

public class AttackState : PlayerState
{
    private Transform _firePoint;
    private float _fireRate;
    private float _nextFireTime;
    private bool _isShooting;
    private IBulletFactory _bulletFactory;

    public AttackState(PlayerStateChanger stateChanger,
                        PlayerMovement movement,
                        PlayerAnimator animator,
                        Transform firePoint,
                        float fireRate,
                        IBulletFactory bulletFactory,
                        PlayerAmmoSystem playerAmmoSystem)
                        : base(stateChanger, movement, animator, playerAmmoSystem)
    {
        _firePoint = firePoint;
        _fireRate = fireRate;
        _bulletFactory = bulletFactory;
        _playerAmmoSystem = playerAmmoSystem;
    }

    public override void Enter()
    {
        base.Enter();
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, true);
        _isShooting = true;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _playerAnimator.SetDirection(_playerMovement.CurrentDirection);

        if (Input.GetMouseButtonUp(0) || !_playerAmmoSystem.HaveBullet())
        {
            _isShooting = false;
            _stateChanger.ChangeState(_stateChanger.IdleState);
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_isShooting && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        CustomEvents.FireChangeBullets(-1);
        _bulletFactory.CreateBullet(_firePoint);
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, true);
        AudioManager.Instance.PlayerOneShot(FMODEvents.Instance.Shoot, _stateChanger.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, false);
    }
}
