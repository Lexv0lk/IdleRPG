using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
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
                _target.Value.GetTakeDamageRequest().Invoke(_damage.Value);
            }
        }
    }
}