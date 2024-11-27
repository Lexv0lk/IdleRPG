using Game.Meta.Upgrades;
using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    [CreateAssetMenu(fileName = "Movement Speed Config", menuName = "Configs/Upgrades/MovementSpeed")]
    public class MovementSpeedUpgradeConfig : UpgradeConfig
    {
        [SerializeField] private MovementSpeedUpgradeTable _movementSpeedUpgradeTable;

        public MovementSpeedUpgradeTable MovementSpeedUpgradeTable => _movementSpeedUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new MovementSpeedUpgrade(this);
        }
    }
}