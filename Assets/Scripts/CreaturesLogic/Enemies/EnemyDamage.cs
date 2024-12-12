using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyInformation _enemyInformation;
    private int _damage;

    private void Awake()
    {
        _enemyInformation = GetComponent<EnemyInformation>();
    }

    private void Start()
    {
        SetupDamage();
    }

    private void SetupDamage()
    {
        _damage = _enemyInformation.GetEnemyInfo().Damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
