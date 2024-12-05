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
    public static class MovementAPI
    {
        ///Keys
        public const int MovementSpeed = 1; // ReactiveVariable<float>
        public const int MoveDirection = 2; // ReactiveVariable<Vector3>
        public const int RotationSpeed = 5; // ReactiveVariable<float>
        public const int MinimalRotationDelta = 7; // float
        public const int CanMove = 4; // ReactiveVariable<bool>
        public const int IsMoving = 8; // ReactiveVariable<bool>
        public const int Destination = 6; // ReactiveVariable<Vector3>
        public const int DistanceToDestination = 24; // ReactiveVariable<float>
        public const int StoppingDistance = 26; // ReactiveVariable<float>
        public const int ForwardDirection = 28; // ReactiveVariable<Vector3>
        public const int CanRotate = 29; // AndExpression
        public const int CanRotateToMoveDirection = 30; // AndExpression


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<bool> GetCanMove(this IEntity obj) => obj.GetValue<ReactiveVariable<bool>>(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanMove(this IEntity obj, out ReactiveVariable<bool> value) => obj.TryGetValue(CanMove, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanMove(this IEntity obj, ReactiveVariable<bool> value) => obj.AddValue(CanMove, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanMove(this IEntity obj) => obj.HasValue(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanMove(this IEntity obj) => obj.DelValue(CanMove);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanMove(this IEntity obj, ReactiveVariable<bool> value) => obj.SetValue(CanMove, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<bool> GetIsMoving(this IEntity obj) => obj.GetValue<ReactiveVariable<bool>>(IsMoving);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsMoving(this IEntity obj, out ReactiveVariable<bool> value) => obj.TryGetValue(IsMoving, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsMoving(this IEntity obj, ReactiveVariable<bool> value) => obj.AddValue(IsMoving, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsMoving(this IEntity obj) => obj.HasValue(IsMoving);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsMoving(this IEntity obj) => obj.DelValue(IsMoving);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsMoving(this IEntity obj, ReactiveVariable<bool> value) => obj.SetValue(IsMoving, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector3> GetDestination(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector3>>(Destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDestination(this IEntity obj, out ReactiveVariable<Vector3> value) => obj.TryGetValue(Destination, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDestination(this IEntity obj, ReactiveVariable<Vector3> value) => obj.AddValue(Destination, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDestination(this IEntity obj) => obj.HasValue(Destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDestination(this IEntity obj) => obj.DelValue(Destination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDestination(this IEntity obj, ReactiveVariable<Vector3> value) => obj.SetValue(Destination, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetDistanceToDestination(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(DistanceToDestination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDistanceToDestination(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(DistanceToDestination, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDistanceToDestination(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(DistanceToDestination, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDistanceToDestination(this IEntity obj) => obj.HasValue(DistanceToDestination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDistanceToDestination(this IEntity obj) => obj.DelValue(DistanceToDestination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDistanceToDestination(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(DistanceToDestination, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<float> GetStoppingDistance(this IEntity obj) => obj.GetValue<ReactiveVariable<float>>(StoppingDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetStoppingDistance(this IEntity obj, out ReactiveVariable<float> value) => obj.TryGetValue(StoppingDistance, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddStoppingDistance(this IEntity obj, ReactiveVariable<float> value) => obj.AddValue(StoppingDistance, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasStoppingDistance(this IEntity obj) => obj.HasValue(StoppingDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelStoppingDistance(this IEntity obj) => obj.DelValue(StoppingDistance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStoppingDistance(this IEntity obj, ReactiveVariable<float> value) => obj.SetValue(StoppingDistance, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveVariable<Vector3> GetForwardDirection(this IEntity obj) => obj.GetValue<ReactiveVariable<Vector3>>(ForwardDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetForwardDirection(this IEntity obj, out ReactiveVariable<Vector3> value) => obj.TryGetValue(ForwardDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddForwardDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.AddValue(ForwardDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasForwardDirection(this IEntity obj) => obj.HasValue(ForwardDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelForwardDirection(this IEntity obj) => obj.DelValue(ForwardDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetForwardDirection(this IEntity obj, ReactiveVariable<Vector3> value) => obj.SetValue(ForwardDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanRotate(this IEntity obj) => obj.GetValue<AndExpression>(CanRotate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanRotate(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanRotate, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanRotate(this IEntity obj, AndExpression value) => obj.AddValue(CanRotate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanRotate(this IEntity obj) => obj.HasValue(CanRotate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanRotate(this IEntity obj) => obj.DelValue(CanRotate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanRotate(this IEntity obj, AndExpression value) => obj.SetValue(CanRotate, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AndExpression GetCanRotateToMoveDirection(this IEntity obj) => obj.GetValue<AndExpression>(CanRotateToMoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetCanRotateToMoveDirection(this IEntity obj, out AndExpression value) => obj.TryGetValue(CanRotateToMoveDirection, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddCanRotateToMoveDirection(this IEntity obj, AndExpression value) => obj.AddValue(CanRotateToMoveDirection, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasCanRotateToMoveDirection(this IEntity obj) => obj.HasValue(CanRotateToMoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelCanRotateToMoveDirection(this IEntity obj) => obj.DelValue(CanRotateToMoveDirection);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCanRotateToMoveDirection(this IEntity obj, AndExpression value) => obj.SetValue(CanRotateToMoveDirection, value);
    }
}
