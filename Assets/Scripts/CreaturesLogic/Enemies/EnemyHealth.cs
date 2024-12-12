using UnityEngine;
using Zenject;

public class EnemyHealth : BaseHealth
{
    [Inject] private readonly HealthCanvas _healthCanvas;
    [SerializeField] private GameObject _healthSliderPrefab;
    [SerializeField] private float _sliderHeightOffset;
    private EnemyInformation _enemyInformation;
    private BaseSlider _healthSlider;
    private GameObject _healthSliderObject;

    private void Awake()
    {
        _enemyInformation = GetComponent<EnemyInformation>();
    }

    public override void SetStartStats()
    {
        MaxHealth = _enemyInformation.GetEnemyInfo().MaxHealth;
        base.SetStartStats();
        CreateHealthBar();
        UpdateSlider();
    }

    private void CreateHealthBar()
    {
        _healthSliderObject = Instantiate(_healthSliderPrefab, _healthCanvas.transform);
        _healthSlider = _healthSliderObject.GetComponent<BaseSlider>();
        _healthSlider.SetupHealth(MaxHealth);
        _healthSlider.SetHeightOffset(_sliderHeightOffset);
        _healthSlider.SetObjectTransform(transform);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        if (_isDeath) return;
        _healthSlider.SetValue(_currentHealth);
        CheckDeath();
    }

    public override void Death()
    {
        Destroy(_healthSliderObject);
        CustomEvents.FireEnemyDie();
        base.Death();
    }
}
