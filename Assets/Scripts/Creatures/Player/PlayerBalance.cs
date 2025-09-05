using UniRx;
using UnityEngine;
public sealed class PlayerBalance : MonoBehaviour
{
    private readonly ReactiveProperty<int> _money = new ReactiveProperty<int>(0);
    public IReadOnlyReactiveProperty<int> Money => _money;


    public void IncreaseMoney(int amount)
    {
        _money.Value += amount;
    }

    public bool TrySpendMoney(int amount)
    {
        if (_money.Value < amount)
        {
            return false;
        }
        _money.Value -= amount;
        return true;
    }
}
