using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class TakeDamageBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IEvent<int> _takeDamageRequest;
        private IEvent<int> _takeDamageEvent;
        private IVariable<int> _currentHealth;
        
        public void Init(IEntity entity)
        {
            _takeDamageRequest = entity.GetTakeDamageRequest();
            _currentHealth = entity.GetHealth();
            _takeDamageEvent = entity.GetTakeDamageEvent();
        }

        public void Enable(IEntity entity)
        {
            _takeDamageRequest.Subscribe(OnTakeDamageRequested);
        }

        public void Disable(IEntity entity)
        {
            _takeDamageRequest.Unsubscribe(OnTakeDamageRequested);
        }

        private void OnTakeDamageRequested(int damageValue)
        {
            int lastHealth = _currentHealth.Value;
            _currentHealth.Value = Mathf.Max(0, _currentHealth.Value - damageValue);
            int realDamage = lastHealth - _currentHealth.Value;
            _takeDamageEvent.Invoke(realDamage);
        }
    }
}