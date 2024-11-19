using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class AttackBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private IValue<int> _damage;
        private IValue<IEntity> _target;
        private IEvent _attackAction;
        private IPredicate _canAttack;
        
        public void Init(IEntity entity)
        {
            _damage = entity.GetDamage();
            _target = entity.GetTarget();
            _canAttack = entity.GetCanAttack();
            _attackAction = entity.GetAttackAction();
        }
        
        public void Enable(IEntity entity)
        {
            _attackAction.OnEvent += Attack;
        }

        public void Disable(IEntity entity)
        {
            _attackAction.OnEvent -= Attack;
        }
        
        private void Attack()
        {
            if (_canAttack.Invoke())
            {
                var targetHealth = _target.Value.GetHealth();

                if (targetHealth.Value > 0)
                    targetHealth.Value = Mathf.Max(0, targetHealth.Value - _damage.Value);
            }
        }
    }
}