namespace Game.Gameplay.GameStates
{
    public interface IGameUpdateListener
    {
        
    }

    public interface IGameFixedUpdateListener : IGameUpdateListener
    {
        void OnFixedUpdate(float deltaTime);
    }

    public interface IGameSimpleUpdateListener : IGameUpdateListener
    {
        void OnUpdate(float deltaTime);
    }
}