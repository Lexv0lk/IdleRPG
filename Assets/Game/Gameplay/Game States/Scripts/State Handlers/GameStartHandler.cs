namespace Game.Gameplay.GameStates
{
    public class GameStartHandler : GameStateHandler<IGameStartListener>
    {
        protected override void ChangeModelState(GameStateModel model)
        {
            model.CurrentState = GameState.PLAYING;
        }

        protected override void HandleListener(IGameStartListener listener)
        {
            listener.OnStart();
        }
    }
}