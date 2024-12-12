using TMPro;
using UnityEngine;

public class KillsSystem : MonoBehaviour
{
    [SerializeField] private int _killsAmount;
    [SerializeField] private TextMeshProUGUI _killsText;

    private void Start()
    {
        CustomEvents.OnEnemyDie += ChangeKillsCount;
    }

    private void ChangeKillsCount()
    {
        _killsAmount++;
        UpdateTextView();
        if (_killsAmount >= WorldGameInfo.MaxGameEnemiesCount) CustomEvents.FireGameEnd(GameEndEnum.WinGame);
    }

    private void UpdateTextView()
    {
        _killsText.text = $"Kills: {_killsAmount}";
    }

    private void OnDestroy()
    {
        CustomEvents.OnEnemyDie -= ChangeKillsCount;
    }
}
