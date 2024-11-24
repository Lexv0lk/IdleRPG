using System;
using System.Collections.Generic;
using Game.GameEngine.Inventory.Scripts.Extensions;

namespace Game.GameEngine.Inventory
{
    public class Inventory
    {
        internal readonly List<InventorySlot> _slots = new();
        internal readonly Dictionary<string, List<InventorySlot>> _slotsById = new();

        public event Action<InventoryItem> ItemAdded;
        public event Action<InventoryItem> ItemRemoved; 
        
        public void Add(InventoryItemConfig itemConfig, int count = 1)
        {
            Add(itemConfig.Prototype.Clone(), count);
        }

        private void Add(InventoryItem item, int count = 1)
        {
            if (item.FlagsExists(InventoryItemFlags.STACKABLE))
            {
                if (_slotsById.ContainsKey(item.Id))
                    AddToExistingSlot(item, count);
                else
                    AddToNewSlot(item, count);
            }
            else
            {
                AddToNewSlot(item, count);
            }
        }

        public bool TryRemove(InventoryItem item, int count = 1)
        {
            
        }

        private void AddToExistingSlot(InventoryItem item, int count)
        {
            _slotsById[item.Id][0].Count += count;
        }

        private void AddToNewSlot(InventoryItem item, int count)
        {
            var slot = new InventorySlot
            {
                Item = item,
                Count = count
            };
            
            _slots.Add(slot);

            if (_slotsById.ContainsKey(item.Id))
                _slotsById[item.Id].Add(slot);
            else
                _slotsById[item.Id] = new List<InventorySlot>() { slot };
        }
    }

    public class InventorySlot
    {
        public InventoryItem Item;
        public int Count;

        public string Id => Item.Id;
    }
}