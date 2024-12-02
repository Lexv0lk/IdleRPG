using Game.GameEngine.Resource;
using Game.Gameplay.Resource;
using Zenject;

namespace GameEngine.DI
{
    public class ResourcesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResourcesStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesManager>().AsSingle().NonLazy();
        }
    }
}