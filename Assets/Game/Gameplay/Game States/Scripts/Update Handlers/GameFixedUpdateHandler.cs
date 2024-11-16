namespace Game.Gameplay.GameStates
{
    public class GameFixedUpdateHandler : GameUpdateHandler<IGameFixedUpdateListener>
    {
        protected override void HandleListener(IGameFixedUpdateListener listener, float deltaTime)
        {
            listener.OnFixedUpdate(deltaTime);
        }
    }
}