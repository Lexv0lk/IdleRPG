using System;
using System.Collections.Generic;
using Game.GameEngine.Resource;
using UnityEngine;

namespace Game.Meta.Rewards
{
    [Serializable]
    public class ResourceReward : IReward
    {
        [SerializeField] private Dictionary<ResourceType, int> _resources = new();

        public IReadOnlyDictionary<ResourceType, int> Resources => _resources;
        
        public void Accept(IRewardVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}