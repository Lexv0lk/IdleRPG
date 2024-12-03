using System.Linq;
using Game.Configs;
using Game.GameEngine.Resource;
using Game.Meta.Upgrades;
using UniRx;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeListViewPresenter
    {
        private readonly UpgradesManager _upgradesManager;
        private readonly ResourcesStorage _resourcesStorage;
        private readonly ResourcesCatalog _resourcesCatalog;
        private readonly ReactiveCollection<UpgradeViewPresenter> _upgradePresenters;

        public IReadOnlyReactiveCollection<UpgradeViewPresenter> UpgradePresenters 
            => _upgradePresenters;

        public UpgradeListViewPresenter(UpgradesManager upgradesManager, ResourcesStorage resourcesStorage,
            ConfigService configService)
        {
            _upgradesManager = upgradesManager;
            _resourcesStorage = resourcesStorage;
            _resourcesCatalog = configService.GetConfig<ResourcesCatalog>();

            _upgradePresenters 
                = new ReactiveCollection<UpgradeViewPresenter>(upgradesManager.GetAllUpgrades()
                    .Select(u => new UpgradeViewPresenter(u, _upgradesManager, _resourcesStorage, _resourcesCatalog)));
        }
    }
}