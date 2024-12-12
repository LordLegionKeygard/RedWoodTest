using System;

public class CustomEvents
{
    public static event Action<int> OnChangeBullets;
    public static void FireChangeBullets(int amount)
    {
        OnChangeBullets?.Invoke(amount);
    }
}
