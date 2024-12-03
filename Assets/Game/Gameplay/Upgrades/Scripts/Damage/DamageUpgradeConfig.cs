using Game.Meta.Upgrades;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "Damage Upgrade Config", menuName = "Configs/Upgrades/Damage")]
    public class DamageUpgradeConfig : UpgradeConfig
    {
        [SerializeField] private DamageUpgradeTable _damageUpgradeTable;

        public DamageUpgradeTable DamageUpgradeTable => _damageUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new DamageUpgrade(this);
        }
        
        protected override void OnValidate()
        {
            base.OnValidate();
            _damageUpgradeTable.OnValidate(MaxLevel);
        }
    }
}