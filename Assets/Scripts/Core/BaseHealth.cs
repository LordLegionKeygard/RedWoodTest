using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    protected int _currentHealth;
    public int MaxHealth;
    protected bool _isDeath;

    private void Start()
    {
        CustomEvents.OnClearScene += Clear;
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
        if (_currentHealth <= 0) Death(false);
    }

    private void Clear()
    {
        Death(true);
    }

    public virtual void Death(bool endGame)
    {
        _isDeath = true;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        CustomEvents.OnClearScene -= Clear; 
    }
}
