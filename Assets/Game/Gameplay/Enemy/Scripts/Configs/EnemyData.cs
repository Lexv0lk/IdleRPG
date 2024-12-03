using System;
using System.Collections.Generic;
using Game.Meta.Rewards;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Enemies/Data", order = 0)]
    public class EnemyData : SerializedScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private EnemyMetadata _metadata;
        [OdinSerialize] private IReward[] _rewards = Array.Empty<IReward>();
        
        public string Id => _id;
        public EnemyMetadata Metadata => _metadata;
        public IReadOnlyCollection<IReward> Rewards => _rewards;
    }
}