using Atomic.Entities;
using UnityEngine;

namespace Game.GameEngine.Triggers
{
    public abstract class BaseTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out SceneEntity entity))
                OnEntered(entity);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out SceneEntity entity))
                OnExited(entity);
        }

        protected virtual void OnEntered(IEntity entity) { }
        protected virtual void OnExited(IEntity entity) { }
    }
}