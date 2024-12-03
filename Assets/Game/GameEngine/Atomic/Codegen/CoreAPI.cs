/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using UnityEngine.AI;
using Game.Meta.Rewards;
using Game.Gameplay.Enemy;

namespace Atomic.Entities
{
    public static class CoreAPI
    {
        ///Keys
        public const int Transform = 3; // Transform
        public const int NavMeshAgent = 20; // NavMeshAgent


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NavMeshAgent GetNavMeshAgent(this IEntity obj) => obj.GetValue<NavMeshAgent>(NavMeshAgent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetNavMeshAgent(this IEntity obj, out NavMeshAgent value) => obj.TryGetValue(NavMeshAgent, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddNavMeshAgent(this IEntity obj, NavMeshAgent value) => obj.AddValue(NavMeshAgent, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasNavMeshAgent(this IEntity obj) => obj.HasValue(NavMeshAgent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelNavMeshAgent(this IEntity obj) => obj.DelValue(NavMeshAgent);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetNavMeshAgent(this IEntity obj, NavMeshAgent value) => obj.SetValue(NavMeshAgent, value);
    }
}
