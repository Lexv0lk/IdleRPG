namespace Game.Gameplay.GameStates
{
    public class GameResumeHandler : GameStateHandler<IGamePauseListener>
    {
        protected override void ChangeModelState(GameStateModel model)
        {
            model.CurrentState = GameState.PLAYING;
        }

        protected override void HandleListener(IGamePauseListener listener)
        {
            listener.OnResume();
        }
    }
}