using System;
using System.Collections.Generic;

namespace Game.GameEngine.Resource
{
    public class ResourcesStorage
    {
        private readonly Dictionary<ResourceType, int> _resources = new();

        public IReadOnlyDictionary<ResourceType, int> Resources => _resources;

        public event Action<ResourceType, int> ResourceAdded;
        public event Action<ResourceType, int> ResourceSpent;
        public event Action<ResourceType, int> ResourceChanged;

        public void Add(ResourceType resourceType, int value)
        {
            if (_resources.ContainsKey(resourceType) == false)
                _resources.Add(resourceType, 0);

            _resources[resourceType] += value;
            ResourceAdded?.Invoke(resourceType, value);
            ResourceChanged?.Invoke(resourceType, _resources[resourceType]);
        }

        public void Remove(ResourceType resourceType, int value)
        {
            _resources[resourceType] -= value;
            ResourceSpent?.Invoke(resourceType, value);
            ResourceChanged?.Invoke(resourceType, _resources[resourceType]);
        }

        public bool CanRemove(ResourceType resourceType, int value)
        {
            return _resources.TryGetValue(resourceType, out int resourceVal) && resourceVal >= value;
        }

        public bool TryRemove(ResourceType resourceType, int value)
        {
            if (CanRemove(resourceType, value))
            {
                Remove(resourceType, value);
                return true;
            }

            return false;
        }

        public int GetCount(ResourceType resourceType)
        {
            if (_resources.TryGetValue(resourceType, out int value))
                return value;

            return 0;
        }

        public bool Contains(ResourceType resourceType)
        {
            return GetCount(resourceType) > 0;
        }
    }
}