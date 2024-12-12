public class PlayerHealth : BaseHealth
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        CheckDeath();
    }

    public override void Death()
    {
        CustomEvents.FireGameEnd(GameEndEnum.LoseGameTakeDamage);
        base.Death();
    }
}
