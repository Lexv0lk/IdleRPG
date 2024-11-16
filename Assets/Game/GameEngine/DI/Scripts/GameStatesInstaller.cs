using Game.Gameplay.GameStates;
using Zenject;

public class GameStatesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameStateModel>().FromNew().AsSingle();
    }
}