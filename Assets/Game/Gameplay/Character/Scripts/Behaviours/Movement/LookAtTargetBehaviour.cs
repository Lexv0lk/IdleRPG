using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class LookAtTargetBehaviour : IEntityInit, IEntityEnable, IEntityDisable, IEntityUpdate
    {
        private IReactiveValue<IEntity> _target;
        private IVariable<Vector3> _forwardDirection;
        
        private Transform _root;
        private Transform _targetRoot;
                
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
            _forwardDirection = entity.GetForwardDirection();
            _root = entity.GetTransform();
        }

        public void Enable(IEntity entity)
        {
            _target.Subscribe(OnTargetChanged);
        }

        public void Disable(IEntity entity)
        {
            _target.Unsubscribe(OnTargetChanged);
        }
        
        public void OnUpdate(IEntity entity, float deltaTime)
        {
            if (_targetRoot != null)
                _forwardDirection.Value = (_targetRoot.position - _root.position).normalized;
        }

        private void OnTargetChanged(IEntity newTarget)
        {
            if (newTarget == null)
                _targetRoot = null;
            else
                _targetRoot = newTarget.GetTransform();
        }
    }
}