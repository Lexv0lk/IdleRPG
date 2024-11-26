using System.Threading;
using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.GameEngine.Atomic.Behaviours
{
    public class PatrolBehaviour : IEntityInit, IEntityEnable, IEntityDisable, IEntityUpdate
    {
        private readonly float _patrolRangeAccuracy;
        private readonly float _minimalIdleTime;
        private readonly float _maximalIdleTime;

        private Transform[] _waypoints;
        private ReactiveInt _currentWaypointIndex;
        private IReactiveVariable<Vector3> _destination;
        private IValue<bool> _isMoving;
        private IValue<bool> _canPatrol;
        private IReactiveVariable<float> _stoppingDistance;
        
        private CancellationTokenSource _cts;
        private bool _isInPatrol;
        private bool _lastCanPatrolValue;

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
            
            _currentWaypointIndex.Value = Random.Range(0, _waypoints.Length);
        }

        public void Enable(IEntity entity)
        {
            _lastCanPatrolValue = _canPatrol.Value;
            OnPatrolConditionChanged(_canPatrol.Value);
        }

        public void Disable(IEntity entity)
        {
            if (_isInPatrol)
            {
                _cts.Cancel();
                _cts.Dispose();
                _isInPatrol = false;
            }
        }
        
        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_canPatrol.Value != _lastCanPatrolValue)
            {
                OnPatrolConditionChanged(_canPatrol.Value);
                _lastCanPatrolValue = _canPatrol.Value;
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
                    //_currentWaypointIndex.Value = (_currentWaypointIndex.Value + 1) % _waypoints.Length;
                    _currentWaypointIndex.Value = Random.Range(0, _waypoints.Length);
                    await UniTask.Delay((int)Random.Range(_minimalIdleTime, _maximalIdleTime) * 1000,
                        cancellationToken: token);
                }
            }

            _isInPatrol = false;
        }
    }
}