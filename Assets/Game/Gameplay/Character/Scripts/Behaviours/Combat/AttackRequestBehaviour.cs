using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay.Character
{
    public class AttackRequestBehaviour : IEntityInit, IEntityUpdate
    {
        private IValue<float> _attackRate;
        private IEvent _attackRequest;
        private IPredicate _canAttack;

        private float _timeForNextAttack;
        
        public void Init(IEntity entity)
        {
            _attackRate = entity.GetAttackRate();
            _attackRequest = entity.GetAttackRequest();
            _canAttack = entity.GetCanAttack();
        }

        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_timeForNextAttack > 0)
            {
                _timeForNextAttack -= deltaTime;
                return;
            }

            if (_canAttack.Invoke())
            {
                _attackRequest.Invoke();
                _timeForNextAttack = _attackRate.Value;
            }
        }
    }
}