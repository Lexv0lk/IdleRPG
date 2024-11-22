using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class TargetDistanceCalculationBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IReactiveVariable<float> _distanceToTarget;
        private Transform _root;
        private IValue<IEntity> _target;
        
        public void Init(IEntity entity)
        {
            _distanceToTarget = entity.GetDistanceToTarget();
            _target = entity.GetTarget();
            _root = entity.GetTransform();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            if (_target.Value == null)
            {
                _distanceToTarget.Value = float.MaxValue;
            }
            else
            {
                var transform = _target.Value.GetTransform();
                _distanceToTarget.Value = Vector3.Distance(transform.position, _root.position);
            }
        }
    }
}