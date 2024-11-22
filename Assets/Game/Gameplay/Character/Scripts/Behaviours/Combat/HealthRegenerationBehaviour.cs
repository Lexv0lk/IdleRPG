using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay.Character
{
    public class HealthRegenerationBehaviour : IEntityInit, IEntityEnable, IEntityDisable, IEntityUpdate
    {
        private IValue<int> _regenerationValue;
        private IValue<float> _regenerationCooldown;
        private IValue<float> _regenerationIdleTime;
        private IVariable<int> _currentHealth;
        private IValue<int> _maxHealth;
        private IEvent _attackEvent;
        private IEvent<int> _takeDamageEvent;

        private float _timeFromLastCombatAction;
        private float _cooldownLeft;
        
        public void Init(IEntity entity)
        {
            _regenerationValue = entity.GetRegenerationValue();
            _regenerationIdleTime = entity.GetRegenerationIdleTime();
            _regenerationCooldown = entity.GetRegenerationCooldown();
            _currentHealth = entity.GetHealth();
            _maxHealth = entity.GetMaxHealth();
            _attackEvent = entity.GetAttackAction();
            _takeDamageEvent = entity.GetTakeDamageEvent();
        }
        
        public void Enable(IEntity entity)
        {
            _takeDamageEvent.OnEvent += OnTakeDamage;
            _attackEvent.OnEvent += OnAttacked;
        }

        public void Disable(IEntity entity)
        {
            _takeDamageEvent.OnEvent -= OnTakeDamage;
            _attackEvent.OnEvent -= OnAttacked;
        }

        private void OnTakeDamage(int _)
        {
            _timeFromLastCombatAction = 0;
        }

        private void OnAttacked()
        {
            _timeFromLastCombatAction = 0;
        }
        
        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_timeFromLastCombatAction < _regenerationIdleTime.Value)
            {
                _timeFromLastCombatAction += deltaTime;
                return;
            }

            if (_cooldownLeft > 0)
            {
                _cooldownLeft -= deltaTime;
                return;
            }

            if (_currentHealth.Value < _maxHealth.Value)
            {
                _currentHealth.Value += _regenerationValue.Value;
                _cooldownLeft = _regenerationCooldown.Value;
            }
        }
    }
}