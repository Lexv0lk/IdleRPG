using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay.Character
{
    public class AttackForceStopBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IEvent _attackStopAction;
        private IReactiveValue<IEntity> _target;
        private IReactiveValue<float> _distanceToTarget;
        private IValue<float> _attackRange;
        
        public void Init(IEntity entity)
        {
            _attackStopAction = entity.GetAttackStopAction();
            _target = entity.GetTarget();
            _distanceToTarget = entity.GetDistanceToTarget();
            _attackRange = entity.GetAttackRange();
        }
        
        public void Enable(IEntity entity)
        {
            _target.Subscribe(OnTargetChanged);
            _distanceToTarget.Subscribe(OnDistanceToTargetChanged);
        }

        public void Disable(IEntity entity)
        {
            _target.Unsubscribe(OnTargetChanged);
            _distanceToTarget.Unsubscribe(OnDistanceToTargetChanged);
        }

        private void OnTargetChanged(IEntity newTarget)
        {
            if (newTarget == null)
                _attackStopAction.Invoke();
        }

        private void OnDistanceToTargetChanged(float newDistance)
        {
            if (newDistance > _attackRange.Value)
                _attackStopAction.Invoke();
        }
    }
}