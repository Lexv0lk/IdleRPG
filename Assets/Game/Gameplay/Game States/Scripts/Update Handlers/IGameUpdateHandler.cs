namespace Game.Gameplay.GameStates
{
    public interface IGameUpdateHandler
    {
        void Register(IGameUpdateListener listener);
        void Remove(IGameUpdateListener listener);
        void Handle(float deltaTime);
    }
}