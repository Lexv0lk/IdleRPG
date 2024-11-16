/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class MovementAPI
    {
        ///Keys
        public const int MovementSpeed = 1; // ReactiveVariable<float>
        public const int MoveDirection = 2; // ReactiveVariable<Vector3>
        public const int RotationSpeed = 5; // ReactiveVariable<float>
        public const int MinimalRotationDelta = 7; // float


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetMovementSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(MovementSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMovementSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(MovementSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMovementSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(MovementSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMovementSpeed(this IEntity obj) => obj.HasValue(MovementSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMovementSpeed(this IEntity obj) => obj.DelValue(MovementSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMovementSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(MovementSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector3>>(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveDirection(this IEntity obj, out ReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetRotationSpeed(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotationSpeed(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(RotationSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotationSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotationSpeed(this IEntity obj) => obj.HasValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotationSpeed(this IEntity obj) => obj.DelValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotationSpeed(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetMinimalRotationDelta(this IEntity obj) => obj.GetValue<float>(MinimalRotationDelta);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMinimalRotationDelta(this IEntity obj, out float value) => obj.TryGetValue(MinimalRotationDelta, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMinimalRotationDelta(this IEntity obj, float value) => obj.AddValue(MinimalRotationDelta, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMinimalRotationDelta(this IEntity obj) => obj.HasValue(MinimalRotationDelta);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMinimalRotationDelta(this IEntity obj) => obj.DelValue(MinimalRotationDelta);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMinimalRotationDelta(this IEntity obj, float value) => obj.SetValue(MinimalRotationDelta, value);
    }
}
