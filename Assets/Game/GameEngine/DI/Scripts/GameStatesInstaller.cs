using Game.Gameplay.GameStates;
using Zenject;

namespace GameEngine.DI
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateModel>().FromNew().AsSingle();
            Container.Bind<GameStateController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameListenersInitializer>().AsSingle().NonLazy();
        }
    }
}