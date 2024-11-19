using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class TargetDetectBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private readonly LayerMask _targetsLayerMask;
        
        private IReactiveVariable<IEntity> _target;
        private IValue<float> _visionDistance;
        private IValue<float> _visionAngle;
        private Transform _root;

        private Collider[] _resultsColliders;
        private Collider _previousCollider;

        public TargetDetectBehaviour(LayerMask targetsLayerMask, int targetsBufferSize = 10)
        {
            _targetsLayerMask = targetsLayerMask;
            _resultsColliders = new Collider[targetsBufferSize];
        }
        
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
            _root = entity.GetTransform();
            _visionDistance = entity.GetVisionDistance();
            _visionAngle = entity.GetVisionAngle();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            int enemyCount = Physics.OverlapSphereNonAlloc(_root.position, _visionDistance.Value, _resultsColliders, _targetsLayerMask);

            if (enemyCount == 0)
            {
                _target.Value = null;
                _previousCollider = null;
                return;
            }

            var closestTarget = _resultsColliders
                .Take(enemyCount)
                .Where(x => Vector3.Angle(_root.forward, x.transform.position - _root.position) <= _visionAngle.Value)
                .OrderBy(x => (x.transform.position - _root.position).sqrMagnitude)
                .FirstOrDefault();

            if (closestTarget == null)
            {
                _target.Value = null;
                _previousCollider = null;
                return;
            }

            if (_previousCollider != closestTarget)
                _target.Value = closestTarget.GetComponent<SceneEntity>();

            _previousCollider = closestTarget;
        }
    }
}