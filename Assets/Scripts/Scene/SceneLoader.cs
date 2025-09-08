using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    [Inject] private SignalBus _bus;
    private void Start() => _bus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
    private void OnDestroy() => _bus.TryUnsubscribe<PlayerDiedSignal>(OnPlayerDied);
    private void OnPlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
