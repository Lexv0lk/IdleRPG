using UnityEngine;

namespace Game.Gameplay.Upgrades
{
    public class UpgradeViewsService : MonoBehaviour
    {
        [SerializeField] private UpgradeListView _upgradeListView;

        public UpgradeListView UpgradeListView => _upgradeListView;
    }
}