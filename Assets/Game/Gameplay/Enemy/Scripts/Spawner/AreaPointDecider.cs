using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    [Serializable]
    public class AreaPointDecider
    {
        [SerializeField] private Transform[] _areaPoints;
        [SerializeField] private float _playerViewRange;

        public Transform[] AllPoints => _areaPoints;

        public Transform GetPoint(IEnumerable<IEntity> currentEnemies, IEntity hero)
        {
            var heroTransform = hero.GetTransform();
            var destinations = currentEnemies.Select(e => PatrolAPI.GetWaypoints(e)[PatrolAPI.GetCurrentWaypointIndex(e).Value]);
            var pointsOutOfRange =
                _areaPoints.Where(p => Vector3.Distance(p.position, heroTransform.position) > _playerViewRange).ToArray();

            if (pointsOutOfRange.Any())
                return pointsOutOfRange.OrderBy(p => destinations.Count(d => d == p)).First();
            else
                return _areaPoints.OrderBy(p => destinations.Count(d => d == p)).First();
        }
    }
}