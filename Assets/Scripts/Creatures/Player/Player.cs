using UnityEngine.SceneManagement;
using Zenject;

public class Player : Creature
{

    [Inject] private SignalBus _bus;
    public override void Death()
    {
        _bus.Fire(new PlayerDiedSignal());
    }
}
