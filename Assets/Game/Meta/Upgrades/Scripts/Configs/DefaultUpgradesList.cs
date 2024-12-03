using Game.Configs;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    [CreateAssetMenu(fileName = "Default Upgrades List", menuName = "Configs/Upgrades List", order = 0)]
    public class DefaultUpgradesList : ScriptableObject, IConfig
    {
        [SerializeField] private UpgradeConfig[] _availableUpgrades;

        public UpgradeConfig[] Upgrades => _availableUpgrades;
    }
}