using System;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterCoreInstaller : IEntityInstaller
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Transform _transform;
        
        public void Install(IEntity entity)
        {
            entity.AddNavMeshAgent(_navMeshAgent);
            entity.AddTransform(_transform);
        }
    }
}