using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay.Character
{
    public class AttackForceStopBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IEvent _attackStopAction;
        private IReactiveValue<IEntity> _target;
        
        public void Init(IEntity entity)
        {
            _attackStopAction = entity.GetAttackStopAction();
            _target = entity.GetTarget();
        }
        
        public void Enable(IEntity entity)
        {
            _target.Subscribe(OnTargetChanged);
        }

        public void Disable(IEntity entity)
        {
            _target.Unsubscribe(OnTargetChanged);
        }

        private void OnTargetChanged(IEntity newTarget)
        {
            if (newTarget == null)
                _attackStopAction.Invoke();
        }
    }
}