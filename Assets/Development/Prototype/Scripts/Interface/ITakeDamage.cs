public interface ITakeDamage
{
    public int health { get; set; }

    public void TakeDamage(int damageAmount);
}
