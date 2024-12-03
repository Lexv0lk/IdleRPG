using Game.GameEngine.Resource;
using Game.Gameplay.Resource;
using Zenject;

namespace GameEngine.DI
{
    public class MetaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallResources();
            InstallUpgrades();
        }

        private void InstallUpgrades()
        {
            
        }

        private void InstallResources()
        {
            Container.Bind<ResourcesStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesManager>().AsSingle().NonLazy();
        }
    }
}