/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;
using UnityEngine.AI;
using Game.Meta.Rewards;

namespace Atomic.Entities
{
    public static class EnemyAPI
    {
        ///Keys
        public const int EnemyId = 39; // string
        public const int Loot = 42; // IReward[]


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetEnemyId(this IEntity obj) => obj.GetValue<string>(EnemyId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetEnemyId(this IEntity obj, out string value) => obj.TryGetValue(EnemyId, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddEnemyId(this IEntity obj, string value) => obj.AddValue(EnemyId, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEnemyId(this IEntity obj) => obj.HasValue(EnemyId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelEnemyId(this IEntity obj) => obj.DelValue(EnemyId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEnemyId(this IEntity obj, string value) => obj.SetValue(EnemyId, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReward[] GetLoot(this IEntity obj) => obj.GetValue<IReward[]>(Loot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetLoot(this IEntity obj, out IReward[] value) => obj.TryGetValue(Loot, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddLoot(this IEntity obj, IReward[] value) => obj.AddValue(Loot, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasLoot(this IEntity obj) => obj.HasValue(Loot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelLoot(this IEntity obj) => obj.DelValue(Loot);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetLoot(this IEntity obj, IReward[] value) => obj.SetValue(Loot, value);
    }
}
