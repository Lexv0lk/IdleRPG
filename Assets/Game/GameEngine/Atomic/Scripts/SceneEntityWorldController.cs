using Game.Gameplay.GameStates;
using UnityEngine;

namespace Atomic.Entities
{
    [AddComponentMenu("Atomic/Entities/Entity World Controller")]
    [DefaultExecutionOrder(-1000)]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneEntityWorld))]
    public sealed class SceneEntityWorldController : MonoBehaviour,
        IGameInitializeListener,
        IGameStartListener,
        IGameSimpleUpdateListener,
        IGameFixedUpdateListener
    {
        private SceneEntityWorld world;
        private bool started;

        private void OnEnable()
        {
            if (this.started)
            {
                this.world.EnableEntities();
            }
        }

        private void LateUpdate()
        {
            this.world.LateUpdateEntities(Time.fixedDeltaTime);
        }

        private void OnDisable()
        {
            if (this.started)
            {
                this.world.DisableEntities();
            }
        }

        private void OnDestroy()
        {
            if (this.started)
            {
                this.world.DisposeEntities();
            }
        }

        public void OnInitialize()
        {
            this.world = this.GetComponent<SceneEntityWorld>();
        }

        public void OnStart()
        {
            this.world.InitEntities();
            this.world.EnableEntities();
            this.started = true;
        }

        public void OnFixedUpdate(float deltaTime)
        {
            this.world.FixedUpdateEntities(deltaTime);
        }

        public void OnUpdate(float deltaTime)
        {
            this.world.UpdateEntities(deltaTime);
        }
    }
}