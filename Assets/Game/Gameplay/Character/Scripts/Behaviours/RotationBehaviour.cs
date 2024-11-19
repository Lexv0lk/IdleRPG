using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class RotationBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private Rigidbody _rigidbody;
        private float _minimalRotationDelta;
        
        private IValue<float> _rotationSpeed;
        private IValue<Vector3> _moveDirection;

        private Vector3 _cachedForwardDirection;
        
        public void Init(IEntity entity)
        {
            _rigidbody = entity.GetRigidbody();
            _rotationSpeed = entity.GetRotationSpeed();
            _moveDirection = entity.GetMoveDirection();
            _minimalRotationDelta = entity.GetMinimalRotationDelta();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            _cachedForwardDirection = _moveDirection.Value;

            if (Mathf.Abs(_cachedForwardDirection.x) < _minimalRotationDelta)
                _cachedForwardDirection.x = 0;
            
            if (_cachedForwardDirection != Vector3.zero)
                _rigidbody.transform.forward = Vector3.Slerp(_rigidbody.transform.forward, _cachedForwardDirection.normalized, Time.fixedDeltaTime * _rotationSpeed.Value);
        }
    }
}