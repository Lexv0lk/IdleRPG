using Atomic.Entities;
using Game.Gameplay.Hero;
using Game.Meta.Upgrades;
using Zenject;

namespace Game.Gameplay.Upgrades
{
    public class MovementSpeedUpgrade : Upgrade
    {
        private readonly MovementSpeedUpgradeConfig _upgradeConfig;

        private HeroService _heroService;
        
        public MovementSpeedUpgrade(MovementSpeedUpgradeConfig upgradeConfig) : base(upgradeConfig)
        {
            _upgradeConfig = upgradeConfig;
        }

        [Inject]
        private void Construct(HeroService heroService)
        {
            _heroService = heroService;
        }

        public override string CurrentStats => 
            _upgradeConfig.MovementSpeedUpgradeTable.GetSpeed(CurrentLevel).ToString("F2");

        public override string NextImprovement 
            => _upgradeConfig.MovementSpeedUpgradeTable.SpeedStep.ToString("F2");
        
        protected override void LevelUp(int level)
        {
            float speed = _upgradeConfig.MovementSpeedUpgradeTable.GetSpeed(level);
            _heroService.Hero.GetMovementSpeed().Value = speed;
        }
    }
}