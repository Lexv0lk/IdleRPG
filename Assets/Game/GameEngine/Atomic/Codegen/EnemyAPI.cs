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
    public static class EnemyAPI
    {
        ///Keys
        public const int EnemyId = 39; // string


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
    }
}
