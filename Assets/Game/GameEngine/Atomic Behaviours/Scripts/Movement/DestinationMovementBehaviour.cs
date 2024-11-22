using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DestinationMovementBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IReactiveValue<Vector3> _destination;
        private IValue<float> _stoppingDistance;
        private NavMeshAgent _navMeshAgent;
        
        public void Init(IEntity entity)
        {
            _destination = entity.GetDestination();
            _navMeshAgent = entity.GetNavMeshAgent();
            _stoppingDistance = entity.GetStoppingDistance();
        }

        public void Enable(IEntity entity)
        {
            SetDestination(_destination.Value);
            _destination.Subscribe(SetDestination);
        }

        public void Disable(IEntity entity)
        {
            _destination.Unsubscribe(SetDestination);
        }

        private void SetDestination(Vector3 destination)
        {
            _navMeshAgent.stoppingDistance = _stoppingDistance.Value;
            _navMeshAgent.SetDestination(destination);
        }
    }
}