using Game.Meta.Upgrades;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "Attack Speed Config", menuName = "Configs/Upgrades/AttackSpeed")]
    public class AttackSpeedUpgradeConfig : UpgradeConfig
    {
        [SerializeField] private AttackSpeedUpgradeTable _attackSpeedUpgradeTable;

        public AttackSpeedUpgradeTable AttackSpeedUpgradeTable => _attackSpeedUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new AttackSpeedUpgrade(this);
        }
        
        protected override void OnValidate()
        {
            base.OnValidate();
            _attackSpeedUpgradeTable.OnValidate(MaxLevel);
        }
    }
}