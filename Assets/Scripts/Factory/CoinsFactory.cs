using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UniRx;
using UnityEngine;
using Zenject;

public class CoinsFactory : MonoBehaviour
{
    const float Offset = 0.05f;
    const float RandomForce = 12f;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _defaultSpawnPoint;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _volumeForSpawn;

    private CancellationTokenSource _cancel;

    [Inject] private SignalBus _bus;

    private void Start()
    {
        _bus.Subscribe<AlarmLevelSignal>(OnAlarmLevelUpdated);
    }

    private void OnAlarmLevelUpdated(AlarmLevelSignal signal)
    {
        if (signal.Volume >= _volumeForSpawn + Offset && _cancel == null)
        {
            _cancel = new CancellationTokenSource();
            Cooldown(_cancel.Token).Forget();
        }
        else if (signal.Volume < _volumeForSpawn - Offset && _cancel != null)
        {
            _cancel?.Cancel();
            _cancel?.Dispose();
            _cancel = null;
        }
    }

    public GameObject Create(Transform spawnPoint = null)
    {
        Transform point = spawnPoint ?? _defaultSpawnPoint;
        GameObject enemy = Instantiate(_enemyPrefab, point.position, point.rotation);
        enemy.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-RandomForce, RandomForce) * RandomForce, 0));
        return enemy;
    }

    private async UniTaskVoid Cooldown(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Create();
            await UniTask.Delay(TimeSpan.FromSeconds(_spawnCooldown), cancellationToken: token);
        }
    }
    private void OnDestroy()
    {
        _bus.TryUnsubscribe<AlarmLevelSignal>(OnAlarmLevelUpdated);
        _cancel?.Cancel();
        _cancel?.Dispose();
        _cancel = null;
    }
}
