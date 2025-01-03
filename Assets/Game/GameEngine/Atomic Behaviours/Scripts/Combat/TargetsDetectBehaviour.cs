﻿using System;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class TargetsDetectBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private readonly LayerMask _targetsLayerMask;
        
        private IValue<float> _visionDistance;
        private IValue<float> _visionAngle;
        private Transform _root;

        private Collider[] _resultsColliders;

        public TargetsDetectBehaviour(LayerMask targetsLayerMask, int targetsBufferSize = 10)
        {
            _targetsLayerMask = targetsLayerMask;
            _resultsColliders = new Collider[targetsBufferSize];
        }
        
        public void Init(IEntity entity)
        {
            _root = entity.GetTransform();
            _visionDistance = entity.GetVisionDistance();
            _visionAngle = entity.GetVisionAngle();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            int enemyCount = Physics.OverlapSphereNonAlloc(_root.position, _visionDistance.Value, _resultsColliders, _targetsLayerMask);

            if (enemyCount == 0)
            {
                entity.SetPossibleTargets(Array.Empty<Collider>());
                return;
            }

            var closestTargets = _resultsColliders
                .Take(enemyCount)
                .Where(x => Vector3.Angle(_root.forward, x.transform.position - _root.position) <= _visionAngle.Value)
                .OrderBy(x => (x.transform.position - _root.position).sqrMagnitude);
            
            entity.SetPossibleTargets(closestTargets.ToArray());
        }
    }
}