using Game.Configs;
using Game.GameEngine.Resource;
using Game.Gameplay.GameStates;
using Game.Meta.Upgrades;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeViewsInitializer : IGameInitializeListener
    {
        private readonly UpgradeViewsService _viewsService;
        private readonly UpgradesManager _upgradesManager;
        private readonly ResourcesStorage _resourcesStorage;
        private readonly ConfigService _configService;

        public UpgradeViewsInitializer(UpgradeViewsService viewsService, UpgradesManager upgradesManager,
            ResourcesStorage resourcesStorage, ConfigService configService)
        {
            _viewsService = viewsService;
            _upgradesManager = upgradesManager;
            _resourcesStorage = resourcesStorage;
            _configService = configService;
        }

        public void OnInitialize()
        {
            var upgradeListPresenter =
                new UpgradeListViewPresenter(_upgradesManager, _resourcesStorage, _configService);
            _viewsService.UpgradeListView.Initialize(upgradeListPresenter);
        }
    }
}