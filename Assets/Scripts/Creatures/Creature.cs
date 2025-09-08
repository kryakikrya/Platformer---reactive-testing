using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    protected Health _health;

    private float _invulnerabilityTime = 0.05f;
    private bool _isInvulnerability = false;

    protected virtual void Awake()
    {
        _health = new Health(_maxHealth);
    }

    public Health GetHealthComponent() => _health;
    public void GetDamage(float damage)
    {
        if (_isInvulnerability == false)
        {
            if (_health.TryGetDamage(damage) == false)
            {
                Death();
                _isInvulnerability = true;
                InvulnerabilityFrame().Forget();
            }
        }
    }

    private async UniTask InvulnerabilityFrame()
    {
         await UniTask.Delay(TimeSpan.FromSeconds(_invulnerabilityTime));
        _isInvulnerability = false;
    }
    public abstract void Death();
}
