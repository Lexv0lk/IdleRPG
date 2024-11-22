using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public class HeroMovementInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveVariable<Vector3> _moveDirection;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveDirection(_moveDirection);

            var canRotateToDirection = new AndExpression();
            canRotateToDirection.Append(() => entity.GetTarget().Value == null);
            entity.AddCanRotateToMoveDirection(canRotateToDirection);

            entity.AddBehaviour(new DirectionMovementBehaviour());
            entity.AddBehaviour(new DirectionUpdateIsMovingBehaviour());
            entity.AddBehaviour(new DirectionRotationBehaviour());
        }
    }
}