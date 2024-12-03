using Atomic.Elements;
using Atomic.Entities;

using UnityEngine.AI;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DestinationUpdateIsMovingBehaviour : IEntityInit, IEntityUpdate
    {
        private IValue<bool> _canMove;
        private IReactiveVariable<bool> _isMoving;
        private IValue<float> _distanceToDestination;
        private NavMeshAgent _navMeshAgent;
        private IValue<float> _stoppingDistance;
        
        public void Init(IEntity entity)
        {
            _canMove = entity.GetCanMove();
            _isMoving = entity.GetIsMoving();
            _navMeshAgent = entity.GetNavMeshAgent();
            _distanceToDestination = entity.GetDistanceToDestination();
            _stoppingDistance = entity.GetStoppingDistance();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _isMoving.Value = _canMove.Value && _distanceToDestination.Value > _stoppingDistance.Value; 
        }
    }
}