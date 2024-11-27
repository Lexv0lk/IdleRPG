using Zenject;

namespace Game.Meta.Upgrades
{
    public class UpgradesFactory
    {
        private readonly DiContainer _diContainer;

        public UpgradesFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Upgrade Instantiate(UpgradeConfig config)
        {
            var upgrade = config.InstantiateUpgrade();
            _diContainer.Inject(upgrade);
            return upgrade;
        }
    }
}