/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using UnityEngine.AI;

namespace Atomic.Entities
{
    public static class CombatAPI
    {
        ///Keys
        public const int Target = 9; // ReactiveVariable<IEntity>
        public const int VisionAngle = 10; // ReactiveVariable<float>
        public const int VisionDistance = 11; // ReactiveVariable<float>
        public const int Damage = 12; // ReactiveVariable<int>
        public const int AttackRate = 13; // ReactiveVariable<float>
        public const int Health = 14; // ReactiveVariable<int>
        public const int CanAttack = 15; // AndExpression
        public const int AttackRange = 16; // ReactiveVariable<float>
        public const int DistanceToTarget = 17; // ReactiveVariable<float>
        public const int AttackRequest = 18; // BaseEvent
        public const int AttackAction = 19; // BaseEvent
        public const int AttackStopAction = 21; // BaseEvent
        public const int MaxHealth = 27; // ReactiveVariable<int>
        public const int IsDead = 31; // ReactiveVariable<bool>
        public const int PossibleTargets = 32; // Collider[]
        public const int RegenerationValue = 33; // ReactiveVariable<int>
        public const int RegenerationCooldown = 34; // ReactiveVariable<float>
        public const int RegenerationIdleTime = 35; // ReactiveVariable<float>
        public const int TakeDamageRequest = 36; // BaseEvent<int>
        public const int TakeDamageEvent = 37; // BaseEvent<int>
        public const int DieEvent = 38; // BaseEvent<IEntity>


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<IEntity> GetTarget(this IEntity obj) => obj.GetValue<ReactiveVariable<IEntity>>(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTarget(this IEntity obj, out ReactiveVariable<IEntity> value) => obj.TryGetValue(Target, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTarget(this IEntity obj, ReactiveVariable<IEntity> value) => obj.AddValue(Target, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTarget(this IEntity obj, ReactiveVariable<IEntity> value) => obj.SetValue(Target, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetVisionAngle(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(VisionAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetVisionAngle(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(VisionAngle, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddVisionAngle(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(VisionAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasVisionAngle(this IEntity obj) => obj.HasValue(VisionAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelVisionAngle(this IEntity obj) => obj.DelValue(VisionAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVisionAngle(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(VisionAngle, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetVisionDistance(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(VisionDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetVisionDistance(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(VisionDistance, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddVisionDistance(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(VisionDistance, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasVisionDistance(this IEntity obj) => obj.HasValue(VisionDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelVisionDistance(this IEntity obj) => obj.DelValue(VisionDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVisionDistance(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(VisionDistance, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetDamage(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamage(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(Damage, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamage(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(Damage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamage(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(Damage, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetAttackRate(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(AttackRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRate(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(AttackRate, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRate(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(AttackRate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRate(this IEntity obj) => obj.HasValue(AttackRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRate(this IEntity obj) => obj.DelValue(AttackRate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRate(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(AttackRate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetHealth(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(Health);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHealth(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(Health, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHealth(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(Health, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHealth(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(Health, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanAttack(this IEntity obj) => obj.GetValue<AndExpression>(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanAttack(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanAttack, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanAttack(this IEntity obj, AndExpression value) => obj.AddValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanAttack(this IEntity obj) => obj.HasValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanAttack(this IEntity obj) => obj.DelValue(CanAttack);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanAttack(this IEntity obj, AndExpression value) => obj.SetValue(CanAttack, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetAttackRange(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(AttackRange);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRange(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(AttackRange, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRange(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(AttackRange, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRange(this IEntity obj) => obj.HasValue(AttackRange);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRange(this IEntity obj) => obj.DelValue(AttackRange);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRange(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(AttackRange, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetDistanceToTarget(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(DistanceToTarget);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDistanceToTarget(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(DistanceToTarget, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDistanceToTarget(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(DistanceToTarget, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDistanceToTarget(this IEntity obj) => obj.HasValue(DistanceToTarget);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDistanceToTarget(this IEntity obj) => obj.DelValue(DistanceToTarget);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDistanceToTarget(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(DistanceToTarget, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAttackRequest(this IEntity obj) => obj.GetValue<BaseEvent>(AttackRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackRequest(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AttackRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackRequest(this IEntity obj, BaseEvent value) => obj.AddValue(AttackRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackRequest(this IEntity obj) => obj.HasValue(AttackRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackRequest(this IEntity obj) => obj.DelValue(AttackRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackRequest(this IEntity obj, BaseEvent value) => obj.SetValue(AttackRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAttackAction(this IEntity obj) => obj.GetValue<BaseEvent>(AttackAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackAction(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AttackAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackAction(this IEntity obj, BaseEvent value) => obj.AddValue(AttackAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackAction(this IEntity obj) => obj.HasValue(AttackAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackAction(this IEntity obj) => obj.DelValue(AttackAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackAction(this IEntity obj, BaseEvent value) => obj.SetValue(AttackAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent GetAttackStopAction(this IEntity obj) => obj.GetValue<BaseEvent>(AttackStopAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAttackStopAction(this IEntity obj, out BaseEvent value) => obj.TryGetValue(AttackStopAction, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAttackStopAction(this IEntity obj, BaseEvent value) => obj.AddValue(AttackStopAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAttackStopAction(this IEntity obj) => obj.HasValue(AttackStopAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAttackStopAction(this IEntity obj) => obj.DelValue(AttackStopAction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAttackStopAction(this IEntity obj, BaseEvent value) => obj.SetValue(AttackStopAction, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetMaxHealth(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxHealth(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(MaxHealth, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxHealth(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(MaxHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxHealth(this IEntity obj) => obj.HasValue(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxHealth(this IEntity obj) => obj.DelValue(MaxHealth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxHealth(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(MaxHealth, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<bool> GetIsDead(this IEntity obj) => obj.GetValue<ReactiveVariable<bool>>(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsDead(this IEntity obj, out ReactiveVariable<bool> value) => obj.TryGetValue(IsDead, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.AddValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsDead(this IEntity obj) => obj.HasValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsDead(this IEntity obj) => obj.DelValue(IsDead);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsDead(this IEntity obj, ReactiveVariable<bool> value) => obj.SetValue(IsDead, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Collider[] GetPossibleTargets(this IEntity obj) => obj.GetValue<Collider[]>(PossibleTargets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetPossibleTargets(this IEntity obj, out Collider[] value) => obj.TryGetValue(PossibleTargets, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddPossibleTargets(this IEntity obj, Collider[] value) => obj.AddValue(PossibleTargets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasPossibleTargets(this IEntity obj) => obj.HasValue(PossibleTargets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelPossibleTargets(this IEntity obj) => obj.DelValue(PossibleTargets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetPossibleTargets(this IEntity obj, Collider[] value) => obj.SetValue(PossibleTargets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<int> GetRegenerationValue(this IEntity obj) => obj.GetValue<ReactiveVariable<int>>(RegenerationValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRegenerationValue(this IEntity obj, out ReactiveVariable<int> value) => obj.TryGetValue(RegenerationValue, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRegenerationValue(this IEntity obj, ReactiveVariable<int> value) => obj.AddValue(RegenerationValue, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRegenerationValue(this IEntity obj) => obj.HasValue(RegenerationValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRegenerationValue(this IEntity obj) => obj.DelValue(RegenerationValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRegenerationValue(this IEntity obj, ReactiveVariable<int> value) => obj.SetValue(RegenerationValue, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetRegenerationCooldown(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(RegenerationCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRegenerationCooldown(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(RegenerationCooldown, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRegenerationCooldown(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(RegenerationCooldown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRegenerationCooldown(this IEntity obj) => obj.HasValue(RegenerationCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRegenerationCooldown(this IEntity obj) => obj.DelValue(RegenerationCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRegenerationCooldown(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(RegenerationCooldown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetRegenerationIdleTime(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(RegenerationIdleTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRegenerationIdleTime(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(RegenerationIdleTime, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRegenerationIdleTime(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(RegenerationIdleTime, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRegenerationIdleTime(this IEntity obj) => obj.HasValue(RegenerationIdleTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRegenerationIdleTime(this IEntity obj) => obj.DelValue(RegenerationIdleTime);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRegenerationIdleTime(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(RegenerationIdleTime, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetTakeDamageRequest(this IEntity obj) => obj.GetValue<BaseEvent<int>>(TakeDamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageRequest(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(TakeDamageRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.AddValue(TakeDamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageRequest(this IEntity obj) => obj.HasValue(TakeDamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageRequest(this IEntity obj) => obj.DelValue(TakeDamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.SetValue(TakeDamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetTakeDamageEvent(this IEntity obj) => obj.GetValue<BaseEvent<int>>(TakeDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTakeDamageEvent(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(TakeDamageEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTakeDamageEvent(this IEntity obj, BaseEvent<int> value) => obj.AddValue(TakeDamageEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTakeDamageEvent(this IEntity obj) => obj.HasValue(TakeDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTakeDamageEvent(this IEntity obj) => obj.DelValue(TakeDamageEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTakeDamageEvent(this IEntity obj, BaseEvent<int> value) => obj.SetValue(TakeDamageEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<IEntity> GetDieEvent(this IEntity obj) => obj.GetValue<BaseEvent<IEntity>>(DieEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDieEvent(this IEntity obj, out BaseEvent<IEntity> value) => obj.TryGetValue(DieEvent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDieEvent(this IEntity obj, BaseEvent<IEntity> value) => obj.AddValue(DieEvent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDieEvent(this IEntity obj) => obj.HasValue(DieEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDieEvent(this IEntity obj) => obj.DelValue(DieEvent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDieEvent(this IEntity obj, BaseEvent<IEntity> value) => obj.SetValue(DieEvent, value);
    }
}
