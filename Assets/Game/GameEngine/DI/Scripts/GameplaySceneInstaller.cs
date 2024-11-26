using Atomic.Entities;
using Game.GameEngine.LocationServices;
using Game.GameEngine.Pools;
using Game.Gameplay.Combat;
using Modules.Input;
using Zenject;
using EnemySpawner = Game.Gameplay.Enemy.EnemySpawner;

namespace GameEngine.DI
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DefaultControls>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<SwipeInput>().AsSingle().NonLazy();
            Container.Bind<CameraService>().FromComponentInHierarchy().AsSingle();
            
            Container.BindInterfacesAndSelfTo<SceneEntityWorldController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IEntityWorld>().To<SceneEntityWorld>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentsInHierarchy().AsCached();
            Container.BindInterfacesAndSelfTo<ComplexEntityPool>().FromComponentsInHierarchy().AsCached();

            Container.BindInterfacesAndSelfTo<EnemyKillObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DeadBodyDestroyController>().AsSingle().NonLazy();
        }
    } 
}