using Atomic.Entities;
using Game.GameEngine.LocationServices;
using Game.Meta.Upgrades;
using Zenject;

namespace Game.Gameplay.Upgrades
{
    public class AttackSpeedUpgrade : Upgrade
    {
        private readonly AttackSpeedUpgradeConfig _upgradeConfig;

        private HeroService _heroService;
        
        public AttackSpeedUpgrade(AttackSpeedUpgradeConfig upgradeConfig) : base(upgradeConfig)
        {
            _upgradeConfig = upgradeConfig;
        }

        [Inject]
        private void Construct(HeroService heroService)
        {
            _heroService = heroService;
        }

        public override string CurrentStats => 
            _upgradeConfig.AttackSpeedUpgradeTable.GetSpeed(CurrentLevel).ToString("F2");

        public override string NextImprovement 
            => _upgradeConfig.AttackSpeedUpgradeTable.SpeedStep.ToString("F2");
        
        protected override void LevelUp(int level)
        {
            float speed = _upgradeConfig.AttackSpeedUpgradeTable.GetSpeed(level);
            _heroService.Hero.GetAttackRate().Value = speed;
        }
    }
}