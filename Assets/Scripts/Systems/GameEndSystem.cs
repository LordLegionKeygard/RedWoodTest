using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndSystem : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndPanel;
    [SerializeField] private TextMeshProUGUI _endGametext;

    private void Start()
    {
        CustomEvents.OnGameEnd += GameEnd;
    }

    private void GameEnd(GameEndEnum endEnum)
    {
        _gameEndPanel.SetActive(true);
        switch (endEnum)
        {
            case GameEndEnum.WinGame:
                _endGametext.text = WorldGameInfo.WinGameText;
                _endGametext.color = Color.green;
                break;
            case GameEndEnum.LoseGameEndBullets:
                _endGametext.text = WorldGameInfo.LoseGameEndBulletsText;
                _endGametext.color = Color.red;
                break;
            case GameEndEnum.LoseGameTakeDamage:
                _endGametext.text = WorldGameInfo.LoseGameTakeDamageText;
                _endGametext.color = Color.red;
                break;
        }
    }


    private void OnDestroy()
    {
        CustomEvents.OnGameEnd -= GameEnd;
    }
}

public enum GameEndEnum
{
    WinGame = 0,
    LoseGameEndBullets = 1,
    LoseGameTakeDamage = 2,
}
