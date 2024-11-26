using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterCombatInstaller : IEntityInstaller
    {
        [Header("Vision Settings")] 
        [SerializeField] private ReactiveVariable<float> _visionAngle;
        [SerializeField] private ReactiveVariable<float> _visionDistance;
        
        [Header("Attack Settings")]
        [SerializeField] private ReactiveVariable<int> _damage;
        [SerializeField] private ReactiveVariable<float> _attackRate;
        [SerializeField] private ReactiveVariable<float> _attackRange;
        [SerializeField] private LayerMask _enemyLayerMask;

        [Header("Health Regeneration")] 
        [SerializeField] private ReactiveVariable<int> _regenerationValue;
        [SerializeField] private ReactiveVariable<float> _regenerationCooldown;
        [SerializeField] private ReactiveVariable<float> _regenerationIdleTime;

        [Header("Combat Stats")] 
        [SerializeField] private ReactiveVariable<int> _health;
        
        public void Install(IEntity entity)
        {
            entity.AddTarget(new ReactiveVariable<IEntity>());
            entity.AddVisionAngle(_visionAngle);
            entity.AddVisionDistance(_visionDistance);
            entity.AddDamage(_damage);
            entity.AddAttackRate(_attackRate);
            entity.AddAttackRange(_attackRange);
            entity.AddHealth(_health);
            entity.AddMaxHealth(new ReactiveVariable<int>(_health.Value));
            entity.AddIsDead(new ReactiveVariable<bool>(false));

            entity.AddRegenerationValue(_regenerationValue);
            entity.AddRegenerationCooldown(_regenerationCooldown);
            entity.AddRegenerationIdleTime(_regenerationIdleTime);

            entity.AddTakeDamageRequest(new BaseEvent<int>());
            entity.AddTakeDamageEvent(new BaseEvent<int>());
            entity.AddDieEvent(new BaseEvent<IEntity>());
            
            entity.AddDistanceToTarget(new ReactiveVariable<float>(float.MaxValue));
            
            var canAttack = new AndExpression();
            canAttack.Append(() => entity.GetIsMoving().Value == false);
            canAttack.Append(() => entity.GetTarget().Value != null);
            canAttack.Append(() => entity.GetDistanceToTarget().Value <= entity.GetAttackRange().Value);
            canAttack.Append(() => entity.GetIsDead().Value == false);
            canAttack.Append(() => entity.GetTarget().Value.GetIsDead().Value == false);
            entity.AddCanAttack(canAttack);

            var canRegenerate = new AndExpression();
            canRegenerate.Append(() => entity.GetIsDead().Value == false);
            entity.AddCanRegenerate(canRegenerate);

            entity.AddAttackRequest(new BaseEvent());
            entity.AddAttackAction(new BaseEvent());
            entity.AddAttackStopAction(new BaseEvent());

            entity.AddBehaviour(new TargetsDetectBehaviour(_enemyLayerMask));
            entity.AddBehaviour(new TargetDistanceCalculationBehaviour());
            entity.AddBehaviour(new AttackRequestBehaviour());
            entity.AddBehaviour(new AttackBehaviour());
            entity.AddBehaviour(new AttackForceStopBehaviour());
            entity.AddBehaviour(new LookAtTargetBehaviour());
            entity.AddBehaviour(new DeathBehaviour());
            entity.AddBehaviour(new TargetSelectBehaviour());
            entity.AddBehaviour(new HealthRegenerationBehaviour());
            entity.AddBehaviour(new TakeDamageBehaviour());
        }
    }
}