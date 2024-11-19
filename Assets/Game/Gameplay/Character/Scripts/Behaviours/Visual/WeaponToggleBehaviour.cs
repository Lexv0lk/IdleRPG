using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Character
{
    public class WeaponToggleBehaviour : IEntityInit, IEntityEnable, IEntityDisable
    {
        private readonly GameObject _weaponObject;

        private IReactiveValue<IEntity> _target;

        public WeaponToggleBehaviour(GameObject weaponObject)
        {
            _weaponObject = weaponObject;
        }

        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
        }
        
        public void Enable(IEntity entity)
        {
            _target.Subscribe(OnTargetChanged);
            OnTargetChanged(_target.Value);
        }

        public void Disable(IEntity entity)
        {
            _target.Unsubscribe(OnTargetChanged);
        }

        private void OnTargetChanged(IEntity newTarget)
        {
            _weaponObject.SetActive(newTarget != null);
        }
    }
}