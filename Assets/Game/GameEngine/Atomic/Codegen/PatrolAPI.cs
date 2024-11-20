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
    public static class PatrolAPI
    {
        ///Keys
        public const int Waypoints = 22; // Transform[]
        public const int CurrentWaypointIndex = 23; // ReactiveInt
        public const int CanPatrol = 25; // ReactiveBool


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform[] GetWaypoints(this IEntity obj) => obj.GetValue<Transform[]>(Waypoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetWaypoints(this IEntity obj, out Transform[] value) => obj.TryGetValue(Waypoints, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddWaypoints(this IEntity obj, Transform[] value) => obj.AddValue(Waypoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasWaypoints(this IEntity obj) => obj.HasValue(Waypoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelWaypoints(this IEntity obj) => obj.DelValue(Waypoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetWaypoints(this IEntity obj, Transform[] value) => obj.SetValue(Waypoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetCurrentWaypointIndex(this IEntity obj) => obj.GetValue<ReactiveInt>(CurrentWaypointIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCurrentWaypointIndex(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(CurrentWaypointIndex, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCurrentWaypointIndex(this IEntity obj, ReactiveInt value) => obj.AddValue(CurrentWaypointIndex, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCurrentWaypointIndex(this IEntity obj) => obj.HasValue(CurrentWaypointIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCurrentWaypointIndex(this IEntity obj) => obj.DelValue(CurrentWaypointIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCurrentWaypointIndex(this IEntity obj, ReactiveInt value) => obj.SetValue(CurrentWaypointIndex, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveBool GetCanPatrol(this IEntity obj) => obj.GetValue<ReactiveBool>(CanPatrol);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanPatrol(this IEntity obj, out ReactiveBool value) => obj.TryGetValue(CanPatrol, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanPatrol(this IEntity obj, ReactiveBool value) => obj.AddValue(CanPatrol, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanPatrol(this IEntity obj) => obj.HasValue(CanPatrol);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanPatrol(this IEntity obj) => obj.DelValue(CanPatrol);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanPatrol(this IEntity obj, ReactiveBool value) => obj.SetValue(CanPatrol, value);
    }
}
