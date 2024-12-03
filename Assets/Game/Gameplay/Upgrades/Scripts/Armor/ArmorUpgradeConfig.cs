using Game.Meta.Upgrades;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "Armor Upgrade Config", menuName = "Configs/Upgrades/Armor")]
    public class ArmorUpgradeConfig : UpgradeConfig
    {
        [SerializeField] private ArmorUpgradeTable _armorUpgradeTable;

        public ArmorUpgradeTable ArmorUpgradeTable => _armorUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new ArmorUpgrade(this);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            _armorUpgradeTable.OnValidate(MaxLevel);
        }
    }
}