using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Gameplay.Character
{
    public class DirectionMovementBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IValue<Vector3> _moveDirection;
        private IValue<float> _movementSpeed;
        private IValue<bool> _canMove;
        private NavMeshAgent _navMeshAgent;
        
        public void Init(IEntity entity)
        {
            _navMeshAgent = entity.GetNavMeshAgent();
            _moveDirection = entity.GetMoveDirection();
            _movementSpeed = entity.GetMovementSpeed();
            _canMove = entity.GetCanMove();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            if (_canMove.Value == false)
            {
                _navMeshAgent.velocity = Vector3.zero;
                return;
            }

            _navMeshAgent.velocity = _moveDirection.Value.normalized * _movementSpeed.Value;
        }
    }
}