using DG.Tweening;
using UnityEngine;
using Zenject;

public sealed class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _targetVolume;

    [Inject] private SignalBus _signalBus;

    private void Awake()
    {
        _source.DOKill();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            if (_source.isPlaying == false)
            {
                _source.Play();
            }
            FadeVolume(_targetVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            FadeVolume(0);
        }
    }

    public void FadeVolume(float targetVolume)
    {
        _source.DOKill();
        var fade = _source.DOFade(targetVolume, _fadeDuration).SetEase(Ease.Linear).SetUpdate(true).SetLink(_source.gameObject).OnUpdate(() =>
        {
            _signalBus.Fire(new AlarmLevelSignal(_source.volume));
        });
    }
}
