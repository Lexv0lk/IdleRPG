using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class TargetSelectBehaviour : IEntityInit, IEntityFixedUpdate
    {
        private IVariable<IEntity> _target;
        private Collider[] _possibleTargets;
        
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
        }

        public void OnFixedUpdate(IEntity entity, float deltaTime)
        {
            _possibleTargets = entity.GetPossibleTargets();

            for (int i = 0; i < _possibleTargets.Length; i++)
            {
                if (_possibleTargets[i].TryGetComponent(out SceneEntity targetEntity))
                {
                    if (targetEntity.HasIsDead() && targetEntity.GetIsDead().Value == false)
                    {
                        _target.Value = targetEntity;
                        return;
                    }
                }
            }
            
            _target.Value = null;
        }
    }
}