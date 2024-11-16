namespace Game.Gameplay.GameStates
{
    public class GameInitializeHandler : GameStateHandler<IGameInitializeListener>
    {
        protected override void ChangeModelState(GameStateModel model)
        {
            model.CurrentState = GameState.OFF;
        }

        protected override void HandleListener(IGameInitializeListener listener)
        {
            listener.OnInitialize();
        }
    }
}