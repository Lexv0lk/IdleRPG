namespace Game.Gameplay.GameStates
{
    public class GamePauseHandler : GameStateHandler<IGamePauseListener>
    {
        protected override void ChangeModelState(GameStateModel model)
        {
            model.CurrentState = GameState.PAUSED;
        }

        protected override void HandleListener(IGamePauseListener listener)
        {
            listener.OnPause();
        }
    }
}