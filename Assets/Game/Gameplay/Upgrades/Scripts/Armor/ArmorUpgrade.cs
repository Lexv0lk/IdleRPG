using Atomic.Entities;
using Game.Gameplay.Hero;
using Game.Meta.Upgrades;
using Zenject;

namespace Game.Gameplay.Upgrades
{
    public class ArmorUpgrade : Upgrade
    {
        private readonly ArmorUpgradeConfig _config;

        private HeroService _heroService;
        
        public ArmorUpgrade(ArmorUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        private void Construct(HeroService heroService)
        {
            _heroService = heroService;
        }

        public override string CurrentStats => 
            _config.ArmorUpgradeTable.GetArmor(CurrentLevel).ToString();

        public override string NextImprovement 
            => _config.ArmorUpgradeTable.ArmorStep.ToString();
        
        protected override void LevelUp(int level)
        {
            int armor = _config.ArmorUpgradeTable.GetArmor(level);
            _heroService.Hero.GetArmor().Value = armor;
        }
    }
}