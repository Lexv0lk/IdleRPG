using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class MovementBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IValue<Vector3> _moveDirection;
        private IValue<float> _movementSpeed;
        private Rigidbody _rigidbody;
        private Transform _root;
        
        public void Init(IEntity entity)
        {
            _moveDirection = entity.GetMoveDirection();
            _root = entity.GetTransform();
            _rigidbody = entity.GetRigidbody();
            _movementSpeed = entity.GetMovementSpeed();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            var moveDirection = _moveDirection.Value;
            
            if (moveDirection != Vector3.zero)
                _rigidbody.AddForce(moveDirection.normalized * _movementSpeed.Value, ForceMode.Force);
            
            ControlSpeed();
        }
        
        private void ControlSpeed()
        {
            Vector3 velocity = _rigidbody.velocity;
            Vector3 flatVel = new Vector3(velocity.x, 0, velocity.z);

            if (flatVel.magnitude > _movementSpeed.Value == false)
                return;
        
            Vector3 limitedVel = flatVel.normalized * _movementSpeed.Value;
            _rigidbody.velocity = limitedVel;
        }
    }
}