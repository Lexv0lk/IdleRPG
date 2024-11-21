using Game.GameEngine.LocationServices;
using Modules.Input;
using Zenject;

namespace GameEngine.DI
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DefaultControls>().FromNew().AsSingle();
        
            Container.BindInterfacesAndSelfTo<SwipeInput>().AsSingle().NonLazy();

            Container.Bind<CameraService>().FromComponentInHierarchy().AsSingle();
        }
    } 
}