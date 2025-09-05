using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public sealed class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private PlayerBalance _playerBalance;

    [Inject]
    private void Construct(PlayerBalance playerBalance)
    {
        _playerBalance = playerBalance;
    }

    private void Start()
    {
        _playerBalance.Money
            .DistinctUntilChanged()
            .Subscribe(newCoins => UpdateUI(newCoins));
    }

    private void UpdateUI(int newValue)
    {
        _text.text = newValue.ToString();
    }
}
