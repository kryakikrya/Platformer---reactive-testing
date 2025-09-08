using UniRx;
public class Health
{
    private readonly float _maxHealth;

    public ReactiveProperty<float> CurrentHealth;
    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        CurrentHealth = new ReactiveProperty<float>(maxHealth);
    }
    public float GetMaxHealth() => _maxHealth;
    public bool TryGetDamage(float damage)
    {
        if (CurrentHealth.Value - damage <= 0)
        {
            return false;
        }
        else
        {
            CurrentHealth.Value -= damage;
            return true;
        }
    }
}
