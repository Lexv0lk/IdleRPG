using System;
using System.Collections.Generic;
using System.Linq;
using Game.Configs;
using Game.GameEngine.Resource;

namespace Game.Meta.Upgrades
{
    public class UpgradesManager
    {
        private readonly ResourcesStorage _storage;
        private readonly UpgradesFactory _factory;
        private readonly Dictionary<string, Upgrade> _upgrades = new();

        public UpgradesManager(ResourcesStorage storage, 
            ConfigService configService, UpgradesFactory factory)
        {
            _storage = storage;
            _factory = factory;

            foreach (var upgradeConfig in configService.GetConfig<DefaultUpgradesList>().Upgrades)
            {
                var upgrade = _factory.Instantiate(upgradeConfig);
                _upgrades[upgrade.Id] = upgrade;
            }
        }

        public Upgrade[] GetAllUpgrades()
        {
            return _upgrades.Values.ToArray();
        }

        //TODO: Move to save system
        public void SetupAllUpgrades()
        {
            foreach (var upgrade in _upgrades.Values)
                upgrade.SetupLevel(1);
        }

        public Upgrade GetUpgrade(string id)
        {
            if (_upgrades.ContainsKey(id) == false)
                throw new ArgumentException($"Upgrade with id {id} wasn't found");

            return _upgrades[id];
        }

        public bool CanLevelUp(Upgrade upgrade)
        {
            return upgrade.CurrentLevel < upgrade.MaxLevel &&
                   upgrade.NextPrice <= _storage.GetCount(ResourceType.MONEY);
        }

        public bool CanLevelUp(string upgradeId)
        {
            if (_upgrades.ContainsKey(upgradeId) == false)
                throw new ArgumentException($"Upgrade with id {upgradeId} wasn't found");

            var upgrade = _upgrades[upgradeId];
            return CanLevelUp(upgrade);
        }

        public void LevelUp(string upgradeId)
        {
            if (_upgrades.ContainsKey(upgradeId) == false)
                throw new ArgumentException($"Upgrade with id {upgradeId} wasn't found");

            var upgrade = _upgrades[upgradeId];
            LevelUp(upgrade);
        }

        public void LevelUp(Upgrade upgrade)
        {
            _storage.Remove(ResourceType.MONEY, upgrade.NextPrice);
            upgrade.LevelUp();
        }
    }
}