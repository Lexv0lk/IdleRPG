using System.Collections.Generic;
using System.Linq;
using Game.Configs;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.GameEngine.Resource
{
    [CreateAssetMenu(fileName = "Resources catalog", menuName = "Configs/Resources Catalog")]
    public class ResourcesCatalog : SerializedScriptableObject, IConfig
    {
        [OdinSerialize] private Dictionary<ResourceConfig, int> _initialResources;

        public IReadOnlyDictionary<ResourceConfig, int> InitialResources => _initialResources;

        public ResourceConfig GetConfig(ResourceType resourceType)
        {
            return _initialResources.Keys.First(c => c.Type == resourceType);
        }
    }
}