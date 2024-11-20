using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class TargetFollowBehaviour : IEntityInit, IEntityUpdate, IEntityEnable, IEntityDisable
    {
        private IReactiveVariable<Vector3> _destination;
        private IReactiveValue<IEntity> _target;
        private IValue<float> _attackRange;
        private IReactiveVariable<float> _stoppingDistance;

        private Transform _targetTransform;
        
        public void Init(IEntity entity)
        {
            _destination = entity.GetDestination();
            _target = entity.GetTarget();
            _attackRange = entity.GetAttackRange();
            _stoppingDistance = entity.GetStoppingDistance();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_targetTransform != null)
                _destination.Value = _targetTransform.position;
        }

        public void Enable(IEntity entity)
        {
            _target.Subscribe(OnTargetChanged);
            OnTargetChanged(_target.Value);
        }

        public void Disable(IEntity entity)
        {
            _target.Unsubscribe(OnTargetChanged);
        }

        private void OnTargetChanged(IEntity newTarget)
        {
            if (newTarget == null)
            {
                _targetTransform = null;
            }
            else
            {
                _targetTransform = newTarget.GetTransform();
                _stoppingDistance.Value = _attackRange.Value;
            }
        }
    }
}