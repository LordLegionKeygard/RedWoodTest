public class PlayerHealth : BaseHealth
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        CheckDeath();
    }
}
