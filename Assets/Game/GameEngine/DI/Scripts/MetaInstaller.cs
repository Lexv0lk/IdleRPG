using Game.GameEngine.Resource;
using Game.Gameplay.Resource;
using Game.Gameplay.Upgrades;
using Game.Meta.Upgrades;
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
            Container.Bind<UpgradesFactory>().AsSingle();
            Container.Bind<UpgradesManager>().AsSingle();

            Container.Bind<UpgradeViewsService>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<UpgradeViewsInitializer>().AsSingle().NonLazy();
        }

        private void InstallResources()
        {
            Container.Bind<ResourcesStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesManager>().AsSingle().NonLazy();
        }
    }
}