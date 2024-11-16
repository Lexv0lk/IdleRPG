using Modules.Input;
using Zenject;

public class TestSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DefaultControls>().FromNew().AsSingle();
        
        Container.BindInterfacesAndSelfTo<SwipeInput>().AsSingle().NonLazy();
    }
}