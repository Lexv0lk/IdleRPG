using System;
using System.Collections.Generic;
using System.Linq;
using Game.GameEngine.Inventory.Scripts.Extensions;

namespace Game.GameEngine.Inventory
{
    public class Inventory
    {
        private readonly List<InventorySlot> _slots = new();
        private readonly Dictionary<string, List<InventorySlot>> _slotsById = new();

        public IReadOnlyCollection<InventorySlot> Slots => _slots;

        public event Action<InventoryItem> ItemAdded;
        public event Action<InventoryItem> ItemRemoved; 

        public void Add(InventoryItem item, int count = 1)
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
            if (GetCount(item) >= count)
            {
                string id = item.Id;
                
                while (count > 0)
                {
                    var lastSlot = _slotsById[id][^1];
                    
                    if (lastSlot.Count >= count)
                    {
                        lastSlot.Count -= count;
                        count = 0;
                    }
                    else
                    {
                        count -= lastSlot.Count;
                        lastSlot.Count = 0;
                    }

                    if (lastSlot.Count == 0)
                    {
                        _slots.Remove(lastSlot);
                        _slotsById[id].RemoveAt(_slotsById[id].Count - 1);
                    }
                }

                ItemRemoved?.Invoke(item);
                return true;
            }

            return false;
        }

        public bool Contains(InventoryItem item)
        {
            return GetCount(item) > 0;
        }

        public int GetCount(InventoryItem item)
        {
            if (_slotsById.ContainsKey(item.Id) == false)
                return 0;

            return _slotsById[item.Id].Sum(x => x.Count);
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