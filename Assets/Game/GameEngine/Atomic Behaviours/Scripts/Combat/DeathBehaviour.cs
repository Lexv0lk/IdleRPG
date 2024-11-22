using Atomic.Elements;
using Atomic.Entities;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class DeathBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IVariable<bool> _isDead;
        private IReactiveValue<int> _currentHealth;
        
        public void Init(IEntity entity)
        {
            _isDead = entity.GetIsDead();
            _currentHealth = entity.GetHealth();
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
                _isDead.Value = true;
        }
    }
}