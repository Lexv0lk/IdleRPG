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

            var canPatrol = new AndExpression();
            canPatrol.Append(() => entity.GetTarget().Value == null);
            canPatrol.Append(() => entity.GetIsDead().Value == false);
            entity.AddCanPatrol(canPatrol);

            entity.AddBehaviour(new PatrolBehaviour(_patrolRangeAccuracy, _minimalIdleTime, _maximalIdleTime));
        }
    }
}