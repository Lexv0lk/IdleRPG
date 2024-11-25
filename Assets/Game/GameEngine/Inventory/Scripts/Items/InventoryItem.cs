using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.GameEngine.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        [SerializeField] private string _id;
        [SerializeField] private InventoryItemFlags _flags;
        [SerializeField] private InventoryItemMetadata _metadata;
        [SerializeField] private IInventoryItemComponent[] _components;

        public string Id => _id;
        public InventoryItemFlags Flags => _flags;
        public InventoryItemMetadata Metadata => _metadata;
        public IReadOnlyCollection<IInventoryItemComponent> Components => _components;
        
        public InventoryItem() {}

        public InventoryItem(string id, InventoryItemFlags flags, 
            InventoryItemMetadata metadata, IInventoryItemComponent[] components)
        {
            _id = id;
            _flags = flags;
            _metadata = metadata;
            _components = components;
        }

        public InventoryItem Clone()
        {
            return new InventoryItem(_id, _flags, _metadata, _components.ToArray());
        }
    }
}