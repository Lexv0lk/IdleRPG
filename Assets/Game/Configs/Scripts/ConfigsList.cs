using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "Configs List", menuName = "Configs/Configs List", order = 0)]
    public class ConfigsList : SerializedScriptableObject
    {
        [OdinSerialize] private IConfig[] _configs;

        public IReadOnlyCollection<IConfig> Configs => _configs;
    }
}