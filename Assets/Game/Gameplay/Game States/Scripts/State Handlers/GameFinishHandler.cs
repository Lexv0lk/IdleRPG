namespace Game.Gameplay.GameStates
{
    public class GameFinishHandler : GameStateHandler<IGameFinishListener>
    {
        protected override void ChangeModelState(GameStateModel model)
        {
            model.CurrentState = GameState.OFF;
        }

        protected override void HandleListener(IGameFinishListener listener)
        {
            listener.OnFinish();
        }
    }
}