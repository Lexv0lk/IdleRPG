using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class RotationBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _root;
        private float _minimalRotationDelta;
        
        private IValue<float> _rotationSpeed;
        private IValue<Vector3> _forwardDirection;
        private IValue<bool> _canRotate;

        private Vector3 _cachedForwardDirection;
        private float _cachedRotationDelta;

        public RotationBehaviour(float minimalRotationDelta)
        {
            _minimalRotationDelta = minimalRotationDelta;
        }
        
        public void Init(IEntity entity)
        {
            _root = entity.GetTransform();
            _rotationSpeed = entity.GetRotationSpeed();
            _forwardDirection = entity.GetForwardDirection();
            _canRotate = entity.GetCanRotate();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_canRotate.Value == false)
                return;
            
            _cachedForwardDirection = _forwardDirection.Value;
            
            if (_cachedForwardDirection != Vector3.zero)
                _root.forward = Vector3.Slerp(_root.forward, _cachedForwardDirection.normalized, deltaTime * _rotationSpeed.Value);
        }
    }
}