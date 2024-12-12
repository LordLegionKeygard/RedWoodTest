public class PlayerHealth : BaseHealth
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        CheckDeath();
    }

    public override void Death(bool endGame)
    {
        if (!endGame)
        {
            CustomEvents.FireGameEnd(GameEndEnum.LoseGameTakeDamage);
            AudioManager.Instance.PlayerOneShot(FMODEvents.Instance.PlayerDeath, transform.position);
        }

        base.Death(endGame);
    }
}
