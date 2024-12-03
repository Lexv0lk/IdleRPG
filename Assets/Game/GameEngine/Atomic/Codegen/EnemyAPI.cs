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
    public static class EnemyAPI
    {
        ///Keys
        public const int EnemyData = 39; // EnemyData


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EnemyData GetEnemyData(this IEntity obj) => obj.GetValue<EnemyData>(EnemyData);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetEnemyData(this IEntity obj, out EnemyData value) => obj.TryGetValue(EnemyData, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddEnemyData(this IEntity obj, EnemyData value) => obj.AddValue(EnemyData, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasEnemyData(this IEntity obj) => obj.HasValue(EnemyData);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelEnemyData(this IEntity obj) => obj.DelValue(EnemyData);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetEnemyData(this IEntity obj, EnemyData value) => obj.SetValue(EnemyData, value);
    }
}
