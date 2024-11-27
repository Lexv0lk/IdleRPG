using Game.Meta.Upgrades;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "Damage Upgrade Config", menuName = "Configs/Upgrades/Damage")]
    public class ArmorUpgradeConfig : UpgradeConfig
    {
        [SerializeField] private ArmorUpgradeTable _armorUpgradeTable;

        public ArmorUpgradeTable ArmorUpgradeTable => _armorUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new ArmorUpgrade(this);
        }
    }
}