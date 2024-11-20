using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterMovementInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveVariable<float> _movementSpeed;
        
        public void Install(IEntity entity)
        {
            entity.AddMovementSpeed(_movementSpeed);
            
            entity.AddCanMove(new ReactiveVariable<bool>(true));
            entity.AddIsMoving(new ReactiveVariable<bool>(false));
        }
    }
}