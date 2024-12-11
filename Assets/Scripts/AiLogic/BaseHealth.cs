using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    private void Start()
    {
        SetupHealth();
    }

    private void SetupHealth()
    {

    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (_currentHealth <= 0) Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
