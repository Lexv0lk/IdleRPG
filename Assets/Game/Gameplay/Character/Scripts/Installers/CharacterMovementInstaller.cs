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
        [SerializeField] private ReactiveVariable<float> _rotationSpeed;
        [SerializeField] private ReactiveVariable<Vector3> _moveDirection;
        [SerializeField] private float _minimalRotationDelta;
        
        public void Install(IEntity entity)
        {
            entity.AddMovementSpeed(_movementSpeed);
            entity.AddMoveDirection(_moveDirection);
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddMinimalRotationDelta(_minimalRotationDelta);
            
            entity.AddCanMove(new ReactiveVariable<bool>(true));
            entity.AddIsMoving(new ReactiveVariable<bool>(false));

            entity.AddBehaviour(new MovementBehaviour());
            entity.AddBehaviour(new RotationBehaviour());
            entity.AddBehaviour(new UpdateIsMovingBehaviour());
        }
    }
}