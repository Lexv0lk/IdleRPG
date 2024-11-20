using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Character;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public class HeroMovementInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveVariable<Vector3> _moveDirection;
        [SerializeField] private ReactiveVariable<float> _rotationSpeed;
        [SerializeField] private float _minimalRotationDelta;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveDirection(_moveDirection);
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddMinimalRotationDelta(_minimalRotationDelta);

            entity.AddBehaviour(new DirectionMovementBehaviour());
            entity.AddBehaviour(new DirectionUpdateIsMovingBehaviour());
            entity.AddBehaviour(new DirectionRotationBehaviour());
        }
    }
}