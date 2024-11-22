using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DirectionRotationBehaviour : IEntityInit, IEntityUpdate
    {
        private IValue<Vector3> _moveDirection;
        private IVariable<Vector3> _forwardDirection;
        private IPredicate _canRotate;

        private Vector3 _cachedForwardDirection;
        
        public void Init(IEntity entity)
        {
            _moveDirection = entity.GetMoveDirection();
            _forwardDirection = entity.GetForwardDirection();
            _canRotate = entity.GetCanRotateToMoveDirection();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_canRotate.Invoke())
                _forwardDirection.Value = _moveDirection.Value;
        }
    }
}