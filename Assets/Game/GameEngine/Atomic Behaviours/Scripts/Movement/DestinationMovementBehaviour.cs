﻿using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DestinationMovementBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IReactiveValue<Vector3> _destination;
        private NavMeshAgent _navMeshAgent;
        private IValue<bool> _canMove;
        
        public void Init(IEntity entity)
        {
            _destination = entity.GetDestination();
            _navMeshAgent = entity.GetNavMeshAgent();
            _canMove = entity.GetCanMove();
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
            if (_canMove.Value)
                _navMeshAgent.SetDestination(destination);
        }
    }
}