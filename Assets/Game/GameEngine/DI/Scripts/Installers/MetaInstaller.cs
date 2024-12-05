using Game.GameEngine.Resource;
using Game.Gameplay.Quests;
using Game.Gameplay.Resource;
using Game.Gameplay.Upgrades;
using Game.Meta.Quests;
using Game.Meta.Rewards;
using Game.Meta.Upgrades;
using Zenject;

namespace GameEngine.DI
{
    public class MetaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallResources();
            InstallRewards();
            InstallUpgrades();
            InstallQuests();
        }

        private void InstallUpgrades()
        {
            Container.Bind<UpgradesFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UpgradesManager>().AsSingle();

            Container.Bind<UpgradeViewsService>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<UpgradeViewsInitializer>().AsSingle().NonLazy();
        }

        private void InstallResources()
        {
            Container.Bind<ResourcesStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourcesManager>().AsSingle().NonLazy();
        }

        private void InstallRewards()
        {
            Container.Bind<DefaultRewardGiveController>().AsSingle();
        }

        private void InstallQuests()
        {
            Container.Bind<QuestViewsService>().FromComponentInHierarchy().AsSingle();
            Container.Bind<QuestFactory>().AsSingle();
            Container.Bind<QuestSupplier>().AsSingle();
            Container.BindInterfacesAndSelfTo<QuestsManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<QuestViewsInitializer>().AsSingle();
        }
    }
}