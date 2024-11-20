using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Gameplay.Character
{
    public class DestinationUpdateIsMovingBehaviour : IEntityInit, IEntityUpdate
    {
        private IValue<bool> _canMove;
        private IReactiveVariable<bool> _isMoving;
        private IValue<float> _distanceToDestination;
        private Transform _root;
        private NavMeshAgent _navMeshAgent;
        
        public void Init(IEntity entity)
        {
            _canMove = entity.GetCanMove();
            _isMoving = entity.GetIsMoving();
            _navMeshAgent = entity.GetNavMeshAgent();
            _root = entity.GetTransform();
            _distanceToDestination = entity.GetDistanceToDestination();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _isMoving.Value = _canMove.Value && _distanceToDestination.Value > _navMeshAgent.stoppingDistance; 
        }
    }
}