using System;
using UnityEngine;

namespace Game.Meta.Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private int _maxLevel;
        [SerializeField] private UpgradeMetadata _metadata;
        [SerializeField] private UpgradePriceTable _priceTable;

        public string Id => _id;
        public int MaxLevel => _maxLevel;
        public UpgradeMetadata Metadata => _metadata;
        public UpgradePriceTable PriceTable => _priceTable;

        public abstract Upgrade InstantiateUpgrade();

        private void OnValidate()
        {
            _priceTable.OnValidate(_maxLevel);
        }
    }
}