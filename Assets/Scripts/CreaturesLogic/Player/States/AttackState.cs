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
                        IBulletFactory bulletFactory)
                        : base(stateChanger, movement, animator)
    {
        _firePoint = firePoint;
        _fireRate = fireRate;
        _bulletFactory = bulletFactory;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter - MoveState");
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, true);
        _isShooting = true;
        _nextFireTime = 0;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetMouseButtonUp(0))
        {
            _isShooting = false;
            _stateChanger.ChangeState(_stateChanger.IdleState);
        }

        if (_playerMovement.CurrentDirection != Vector2.zero)
        {
            // _stateChanger.ChangeState(_stateChanger.MoveAttackState);
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
        _bulletFactory.CreateBullet(_firePoint);
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, true);
    }

    public override void Exit()
    {
        base.Exit();
        _playerAnimator.SetBoolAnimation(AnimatorStrings.Attack, false);
    }
}
