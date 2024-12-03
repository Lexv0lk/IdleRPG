using System;

namespace Game.Meta.Upgrades
{
    public abstract class Upgrade
    {
        private readonly UpgradeConfig _upgradeConfig;

        public string Id => _upgradeConfig.Id;
        public UpgradeMetadata Metadata => _upgradeConfig.Metadata;
        public int MaxLevel => _upgradeConfig.MaxLevel;
        public float Progress => (float)CurrentLevel / _upgradeConfig.MaxLevel;
        public int NextPrice => _upgradeConfig.PriceTable.GetPrice(CurrentLevel + 1);
        
        public int CurrentLevel { get; private set; }

        public abstract string CurrentStats { get; }
        public abstract string NextImprovement { get; }
        
        public event Action<int> OnLevelUp;

        protected Upgrade(UpgradeConfig upgradeConfig)
        {
            _upgradeConfig = upgradeConfig;
            CurrentLevel = 1;
        }

        public void SetupLevel(int level)
        {
            CurrentLevel = level;
            LevelUp(level);
        }

        public void LevelUp()
        {
            if (CurrentLevel >= MaxLevel)
                throw new Exception($"Level of upgrade {Id} is already MAX");

            CurrentLevel++;
            LevelUp(CurrentLevel);
            OnLevelUp?.Invoke(CurrentLevel);
        }

        protected abstract void LevelUp(int level);
    }
}