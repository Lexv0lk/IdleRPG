using Game.GameEngine.Resource;
using Game.Meta.Upgrades;
using UniRx;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeViewPresenter
    {
        private readonly Upgrade _upgrade;
        private readonly UpgradesManager _upgradesManager;
        private readonly ResourcesStorage _resourcesStorage;
        private readonly ResourcesCatalog _resourcesCatalog;

        private readonly BoolReactiveProperty _canUpgrade;
        private readonly StringReactiveProperty _currentStats;
        private readonly StringReactiveProperty _nextImprovement;
        private readonly StringReactiveProperty _price;
        private readonly BoolReactiveProperty _isMaxLevel;
        private readonly StringReactiveProperty _level;
        
        public ReactiveCommand LevelUpCommand { get; }
        public string Title { get; }
        public Sprite Icon { get; }

        public IReadOnlyReactiveProperty<string> CurrentStats => _currentStats;
        public IReadOnlyReactiveProperty<string> NextImprovement => _currentStats;
        public IReadOnlyReactiveProperty<bool> IsMaxLevel => _isMaxLevel;
        public IReadOnlyReactiveProperty<string> Level => _level;

        public IReadOnlyReactiveProperty<string> Price => _price;
        public Sprite PriceIcon { get; }
        

        public UpgradeViewPresenter(Upgrade upgrade, UpgradesManager upgradesManager,
            ResourcesStorage resourcesStorage, ResourcesCatalog resourcesCatalog)
        {
            _upgrade = upgrade;
            _upgradesManager = upgradesManager;
            _resourcesStorage = resourcesStorage;
            _resourcesCatalog = resourcesCatalog;

            Title = upgrade.Metadata.Title;
            Icon = upgrade.Metadata.Icon;
            PriceIcon = _resourcesCatalog.GetConfig(ResourceType.MONEY).Icon;
            _currentStats = new StringReactiveProperty(upgrade.CurrentStats);
            _nextImprovement = new StringReactiveProperty(upgrade.NextImprovement);
            
            _canUpgrade = new BoolReactiveProperty(CanLevelUp());
            
            LevelUpCommand = new ReactiveCommand(_canUpgrade, CanLevelUp());
            LevelUpCommand.Subscribe(OnLevelUpCommand);
            
            _resourcesStorage.ResourceChanged += OnResourceChanged;   
        }

        private void OnLevelUpCommand(Unit obj)
        {
            LevelUp();
        }

        private void OnResourceChanged(ResourceType arg1, int arg2)
        {
            _canUpgrade.Value = CanLevelUp();
        }

        private bool CanLevelUp()
        {
            return _upgradesManager.CanLevelUp(_upgrade);
        }

        private void LevelUp()
        {
            
        }

        ~UpgradeViewPresenter()
        {
            _resourcesStorage.ResourceChanged -= OnResourceChanged;   
        }
    }
}