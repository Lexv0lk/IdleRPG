using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyMovementInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddDestination(new ReactiveVariable<Vector3>(entity.GetTransform().position));
            entity.AddDistanceToDestination(new ReactiveVariable<float>());
            entity.AddStoppingDistance(new ReactiveVariable<float>());

            var canRotate = entity.GetCanRotate();
            canRotate.Append(() => entity.GetTarget().Value != null);
            
            entity.AddBehaviour(new DestinationMovementBehaviour());
            entity.AddBehaviour(new DestinationDistanceCalculationBehaviour());
            entity.AddBehaviour(new DestinationUpdateIsMovingBehaviour());
            entity.AddBehaviour(new TargetFollowBehaviour());
        }
    }
}