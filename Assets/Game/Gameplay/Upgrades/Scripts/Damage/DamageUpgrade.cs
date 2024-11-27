using System.Globalization;
using Atomic.Entities;
using Game.GameEngine.LocationServices;
using Game.Meta.Upgrades;
using Zenject;

namespace Game.Gameplay.Upgrades
{
    public class DamageUpgrade : Upgrade
    {
        private readonly DamageUpgradeConfig _config;

        private HeroService _heroService;
        
        public DamageUpgrade(DamageUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        private void Construct(HeroService heroService)
        {
            _heroService = heroService;
        }

        public override string CurrentStats => 
            _config.DamageUpgradeTable.GetDamage(CurrentLevel).ToString();

        public override string NextImprovement 
            => _config.DamageUpgradeTable.DamageStep.ToString();
        
        protected override void LevelUp(int level)
        {
            int damage = _config.DamageUpgradeTable.GetDamage(level);
            _heroService.Hero.GetDamage().Value = damage;
        }
    }
}