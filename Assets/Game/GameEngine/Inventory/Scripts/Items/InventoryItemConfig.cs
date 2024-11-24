using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.GameEngine.Inventory
{
    [CreateAssetMenu(fileName = "Item Config", menuName = "Inventory/Item Config", order = 0)]
    public class InventoryItemConfig : SerializedScriptableObject
    {
        [OdinSerialize] private InventoryItem _item;

        public string Id => _item.Id;
        public InventoryItemFlags Flags => _item.Flags;
        public InventoryItemMetadata Metadata => _item.Metadata;
        public InventoryItem Prototype => _item;
    }
}