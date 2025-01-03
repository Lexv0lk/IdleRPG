﻿using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Character
{
    [Serializable]
    public class CharacterMovementInstaller : IEntityInstaller
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _minimalRotationDelta;
        
        public void Install(IEntity entity)
        {
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddMovementSpeed(_movementSpeed);
            entity.AddForwardDirection(new ReactiveVariable<Vector3>(entity.GetTransform().forward));

            var canRotate = new AndExpression();
            canRotate.Append(() => entity.GetIsDead().Value == false);
            entity.AddCanRotate(canRotate);
            
            entity.AddCanMove(new ReactiveVariable<bool>(true));
            
            entity.AddIsMoving(new ReactiveVariable<bool>(false));
            entity.AddBehaviour(new RotationBehaviour(_minimalRotationDelta));
        }
    }
}