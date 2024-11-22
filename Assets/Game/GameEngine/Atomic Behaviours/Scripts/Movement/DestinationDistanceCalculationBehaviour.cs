using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DestinationDistanceCalculationBehaviour : IEntityInit, IEntityUpdate
    {
        private IReactiveVariable<float> _distanceToDestination;
        private Transform _root;
        private IValue<Vector3> _destination;
        
        public void Init(IEntity entity)
        {
            _distanceToDestination = entity.GetDistanceToDestination();
            _root = entity.GetTransform();
            _destination = entity.GetDestination();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _distanceToDestination.Value = Vector3.Distance(_root.position, _destination.Value);
        }
    }
}