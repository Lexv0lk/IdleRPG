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

        private readonly BoolReactiveProperty _canLevelUp;
        private readonly StringReactiveProperty _description;
        private readonly StringReactiveProperty _price;
        private readonly StringReactiveProperty _level;
        private readonly BoolReactiveProperty _showPrice;
        
        public ReactiveCommand LevelUpCommand { get; }
        public string Title { get; }
        public Sprite Icon { get; }

        public IReadOnlyReactiveProperty<string> Description => _description;
        public IReadOnlyReactiveProperty<string> Level => _level;
        public IReadOnlyReactiveProperty<bool> ShowPrice => _showPrice;

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
            
            _description = new StringReactiveProperty(GetCurrentDescription());
            _level = new StringReactiveProperty(GetCurrentLevel());
            _canLevelUp = new BoolReactiveProperty(CanLevelUp());
            _showPrice = new BoolReactiveProperty(_upgrade.CurrentLevel < _upgrade.MaxLevel);
            _price = new StringReactiveProperty(_upgrade.NextPrice.ToString());
            
            LevelUpCommand = new ReactiveCommand(_canLevelUp, CanLevelUp());
            LevelUpCommand.Subscribe(OnLevelUpCommand);
            
            _resourcesStorage.ResourceChanged += OnResourceChanged;   
        }

        private void OnLevelUpCommand(Unit obj)
        {
            LevelUp();
        }

        private void OnResourceChanged(ResourceType arg1, int arg2)
        {
            _canLevelUp.Value = CanLevelUp();
        }

        private bool CanLevelUp()
        {
            return _upgradesManager.CanLevelUp(_upgrade);
        }

        private void LevelUp()
        {
            _upgradesManager.LevelUp(_upgrade);
            _canLevelUp.Value = CanLevelUp();
            _description.Value = GetCurrentDescription();
            _level.Value = GetCurrentLevel();
            _showPrice.Value = _upgrade.CurrentLevel < _upgrade.MaxLevel;
            _price.Value = _upgrade.NextPrice.ToString();
        }

        private string GetCurrentDescription()
        {
            if (_upgrade.CurrentLevel < _upgrade.MaxLevel)
                return $"Значение: {_upgrade.CurrentStats} (+{_upgrade.NextImprovement})";
            else
                return $"Значение: {_upgrade.CurrentStats}";
        }

        private string GetCurrentLevel()
        {
            return $"Уровень: {_upgrade.CurrentLevel}/{_upgrade.MaxLevel}";
        }

        ~UpgradeViewPresenter()
        {
            _resourcesStorage.ResourceChanged -= OnResourceChanged;   
        }
    }
}