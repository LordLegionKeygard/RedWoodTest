using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    protected int _currentHealth;
    public int MaxHealth;
    protected bool _isDeath;
    
    private void Start()
    {
        SetStartStats();
    }

    
    public virtual void SetStartStats()
    {
        _isDeath = false;
        _currentHealth = MaxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    public void CheckDeath()
    {
        if (_currentHealth <= 0) Death();
    }

    private void Death()
    {
        _isDeath = true;
        Destroy(gameObject);
    }
}
