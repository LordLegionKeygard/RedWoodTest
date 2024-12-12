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
    private EnemyDrop _enemyDrop;

    private void Awake()
    {
        _enemyInformation = GetComponent<EnemyInformation>();
        _enemyDrop = GetComponent<EnemyDrop>();
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
        _healthSlider.SetObjectTransform(transform);
        _healthSlider.SetupHealth(MaxHealth);
        _healthSlider.SetHeightOffset(_sliderHeightOffset);
        _healthSlider.ActiveSlider();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateSlider();
        PlayTakeDamageSound();
    }

    private void PlayTakeDamageSound()
    {
        var rnd = Random.Range(0, 10);

        if (rnd < 1)
        {
            AudioManager.Instance.PlayerOneShot(FMODEvents.Instance.ZombieGrowl, transform.position);
        }
    }

    private void UpdateSlider()
    {
        if (_isDeath) return;
        _healthSlider.SetValue(_currentHealth);
        CheckDeath();
    }

    public override void Death(bool endGame)
    {
        Destroy(_healthSliderObject);

        if (!endGame)
        {
            _enemyDrop.DropItem();
            CustomEvents.FireEnemyDie();
        }
        base.Death(endGame);
    }
}
