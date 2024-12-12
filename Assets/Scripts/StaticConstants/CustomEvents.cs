using System;

public class CustomEvents
{
    public static event Action<int> OnChangeBullets;
    public static void FireChangeBullets(int amount)
    {
        OnChangeBullets?.Invoke(amount);
    }

    public static event Action<GameEndEnum> OnGameEnd;
    public static void FireGameEnd(GameEndEnum state)
    {
        OnGameEnd?.Invoke(state);
    }

    public static event Action OnEnemyDie;
    public static void FireEnemyDie()
    {
        OnEnemyDie?.Invoke();
    }

    public static event Action OnClearScene;
    public static void FireClearScene()
    {
        OnClearScene?.Invoke();
    }
}
