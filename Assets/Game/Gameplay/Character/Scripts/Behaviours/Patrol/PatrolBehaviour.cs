using System.Threading;
using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class PatrolBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private readonly float _patrolRangeAccuracy;
        private readonly float _minimalIdleTime;
        private readonly float _maximalIdleTime;

        private Transform[] _waypoints;
        private ReactiveInt _currentWaypointIndex;
        private IReactiveVariable<Vector3> _destination;
        private IValue<bool> _isMoving;
        private IReactiveValue<bool> _canPatrol;
        private IReactiveVariable<float> _stoppingDistance;
        
        private CancellationTokenSource _cts;
        private bool _isInPatrol;

        public PatrolBehaviour(float patrolRangeAccuracy, float minimalIdleTime, float maximalIdleTime)
        {
            _patrolRangeAccuracy = patrolRangeAccuracy;
            _minimalIdleTime = minimalIdleTime;
            _maximalIdleTime = maximalIdleTime;
        }
        
        public void Init(IEntity entity)
        {
            _waypoints = entity.GetWaypoints();
            _currentWaypointIndex = entity.GetCurrentWaypointIndex();
            _destination = entity.GetDestination();
            _isMoving = entity.GetIsMoving();
            _canPatrol = entity.GetCanPatrol();
            _stoppingDistance = entity.GetStoppingDistance();
        }

        public void Enable(IEntity entity)
        {
            _canPatrol.Subscribe(OnPatrolConditionChanged);
            OnPatrolConditionChanged(_canPatrol.Value);
        }

        public void Disable(IEntity entity)
        {
            _canPatrol.Unsubscribe(OnPatrolConditionChanged);

            if (_isInPatrol)
            {
                _cts.Cancel();
                _cts.Dispose();
                _isInPatrol = false;
            }
        }

        private void OnPatrolConditionChanged(bool canPatrol)
        {
            if (canPatrol && _isInPatrol == false)
            {
                _cts = new CancellationTokenSource();
                ProceedPatrol(_cts.Token);
            }
            else if (canPatrol == false && _isInPatrol)
            {
                _cts.Cancel();
                _cts.Dispose();
                _isInPatrol = false;
            }
        }

        private async UniTask ProceedPatrol(CancellationToken token)
        {
            Vector3 currentWaypointPosition;
            _isInPatrol = true;
            _stoppingDistance.Value = _patrolRangeAccuracy;

            while (token.IsCancellationRequested == false)
            {
                currentWaypointPosition = _waypoints[_currentWaypointIndex.Value].position;
                _destination.Value = currentWaypointPosition;

                await UniTask.NextFrame(cancellationToken: token);

                while (_isMoving.Value && token.IsCancellationRequested == false)
                    await UniTask.NextFrame(cancellationToken: token);

                if (token.IsCancellationRequested == false)
                {
                    _currentWaypointIndex.Value = (_currentWaypointIndex.Value + 1) % _waypoints.Length;
                    await UniTask.Delay((int)Random.Range(_minimalIdleTime, _maximalIdleTime) * 1000,
                        cancellationToken: token);
                }
            }

            _isInPatrol = false;
        }
    }
}