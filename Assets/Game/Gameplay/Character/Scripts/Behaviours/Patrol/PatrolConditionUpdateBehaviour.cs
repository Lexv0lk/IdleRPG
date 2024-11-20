using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay.Character
{
    public class PatrolConditionUpdateBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IReactiveValue<IEntity> _target;
        private IReactiveVariable<bool> _canPatrol;
        
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
            _canPatrol = entity.GetCanPatrol();
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
            _canPatrol.Value = newTarget == null;
        }
    }
}