using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DirectionUpdateIsMovingBehaviour : IEntityInit, IEntityUpdate
    {
        private IValue<bool> _canMove;
        private IValue<Vector3> _moveDirection;
        private IReactiveVariable<bool> _isMoving;
        
        public void Init(IEntity entity)
        {
            _canMove = entity.GetCanMove();
            _moveDirection = entity.GetMoveDirection();
            _isMoving = entity.GetIsMoving();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            _isMoving.Value = _canMove.Value && _moveDirection.Value != Vector3.zero; 
        }
    }
}