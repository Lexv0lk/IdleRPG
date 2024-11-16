namespace Game.Gameplay.GameStates
{
    public class GameSimpleUpdateHandler : GameUpdateHandler<IGameSimpleUpdateListener>
    {
        protected override void HandleListener(IGameSimpleUpdateListener listener, float deltaTime)
        {
            listener.OnUpdate(deltaTime);
        }
    }
}