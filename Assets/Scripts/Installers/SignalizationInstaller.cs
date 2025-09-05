using Zenject;

public sealed class SignalizationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<AlarmLevelSignal>();
    }
}
