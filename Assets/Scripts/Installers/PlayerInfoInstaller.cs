using UnityEngine;
using Zenject;

public sealed class PlayerInfoInstaller : MonoInstaller
{
    [SerializeField] Player _player;
    [SerializeField] PlayerBalance _playerBalance;
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<PlayerBalance>().FromInstance(_playerBalance).AsSingle();
    }
}