using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;
public sealed class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _mainBar;
    [SerializeField] private Image _animatedBar;

    [Space]
    [SerializeField] private float _mainDuration = 0.05f;
    [SerializeField] private float _animationDuration = 1f;
    [SerializeField] private float _animatedBarInterval = 0.5f;

    private Player _player;
    private Health _health;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        _health = _player.GetHealthComponent();

        _health.CurrentHealth
            .Select(cur => cur / (float)_health.GetMaxHealth())
            .DistinctUntilChanged()
            .Subscribe(newFill => AnimateBars(newFill));
    }
    private void AnimateBars(float targetFill)
    {

        _mainBar.DOKill();
        _mainBar.DOFillAmount(targetFill, _mainDuration).SetEase(Ease.OutQuad).SetLink(_mainBar.gameObject);

        _animatedBar.DOKill();

        if (_animatedBar.fillAmount > targetFill)
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(_animatedBarInterval);
            seq.Append(_animatedBar.DOFillAmount(targetFill, _animationDuration));
            seq.SetLink(_animatedBar.gameObject);
        }
        else
        {
            _animatedBar.DOFillAmount(targetFill, _mainDuration).SetEase(Ease.OutQuad).SetLink(_animatedBar.gameObject);
        }
    }
}
