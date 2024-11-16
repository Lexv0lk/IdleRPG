namespace Game.Gameplay.GameStates
{
    public interface IGameStateHandler
    {
        void Register(IGameStateListener listener);
        void Remove(IGameStateListener listener);
        void Handle(GameStateModel model);
    }
}