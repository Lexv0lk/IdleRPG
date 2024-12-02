using System.Linq;
using Game.Meta.Upgrades;
using UniRx;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeListViewPresenter
    {
        private readonly UpgradesManager _upgradesManager;
        private readonly ReactiveCollection<UpgradeViewPresenter> _upgradePresenters;
        
        public IReadOnlyReactiveCollection<UpgradeViewPresenter> UpgradePresenters { get; }

        public UpgradeListViewPresenter(UpgradesManager upgradesManager)
        {
            _upgradesManager = upgradesManager;

            _upgradePresenters 
                = new ReactiveCollection<UpgradeViewPresenter>(upgradesManager.GetAllUpgrades()
                    .Select(u => new UpgradeViewPresenter(u)));
        }
    }
}