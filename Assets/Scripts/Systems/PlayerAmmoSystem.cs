using TMPro;
using UnityEngine;

public class PlayerAmmoSystem : MonoBehaviour
{
    [SerializeField] private int _startBulletsAmount;
    [SerializeField] private int _currentBulletsAmount;
    [SerializeField] private TextMeshProUGUI _bulletsText;
    private int _warningBulletsCount = 3;
    public bool HaveBullet() => _currentBulletsAmount > 0;

    private void Start()
    {
        CustomEvents.OnChangeBullets += ChangeBulletsCount;

        SetupStartBullets();
    }

    private void SetupStartBullets()
    {
        ChangeBulletsCount(_startBulletsAmount);
    }

    private void ChangeBulletsCount(int amount)
    {
        _currentBulletsAmount += amount;
        UpdateTextView();
        if (!HaveBullet()) CustomEvents.FireGameEnd(GameEndEnum.LoseGameEndBullets);
    }

    private void UpdateTextView()
    {
        _bulletsText.color = _currentBulletsAmount <= _warningBulletsCount ? Color.red : Color.black;
        _bulletsText.text = _currentBulletsAmount.ToString();
    }

    private void OnDestroy()
    {
        CustomEvents.OnChangeBullets -= ChangeBulletsCount;
    }
}
