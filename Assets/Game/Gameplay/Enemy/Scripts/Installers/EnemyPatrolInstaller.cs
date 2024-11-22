using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.GameEngine.Atomic.Behaviours;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class EnemyPatrolInstaller : IEntityInstaller
    {
        [SerializeField] private Transform[] _waypoints;
        
        [Header("Patrol Settings")]
        [SerializeField] private float _patrolRangeAccuracy = .15f;
        [SerializeField] private float _minimalIdleTime = 0;
        [SerializeField] private float _maximalIdleTime = 2;
        
        public void Install(IEntity entity)
        {
            entity.AddWaypoints(_waypoints);
            entity.AddCurrentWaypointIndex(new ReactiveInt(0));
            entity.AddCanPatrol(new ReactiveBool(true));

            entity.AddBehaviour(new PatrolConditionUpdateBehaviour());
            entity.AddBehaviour(new PatrolBehaviour(_patrolRangeAccuracy, _minimalIdleTime, _maximalIdleTime));
        }
    }
}