using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterCoreInstaller : IEntityInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;
        
        public void Install(IEntity entity)
        {
            entity.AddRigidbody(_rigidbody);
            entity.AddTransform(_transform);
        }
    }
}