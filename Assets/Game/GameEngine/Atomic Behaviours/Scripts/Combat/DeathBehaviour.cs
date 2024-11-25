using Atomic.Elements;
using Atomic.Entities;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DeathBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IVariable<bool> _isDead;
        private IReactiveValue<int> _currentHealth;
        private IEvent<IEntity> _dieEvent;

        private IEntity _entity;
        
        public void Init(IEntity entity)
        {
            _entity = entity;
            _isDead = entity.GetIsDead();
            _currentHealth = entity.GetHealth();
            _dieEvent = entity.GetDieEvent();
        }

        public void Enable(IEntity entity)
        {
            _currentHealth.Subscribe(OnHealthChanged);
        }

        public void Disable(IEntity entity)
        {
            _currentHealth.Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int newValue)
        {
            if (newValue <= 0)
            {
                _isDead.Value = true;
                _dieEvent.Invoke(_entity);
            }
        }
    }
}