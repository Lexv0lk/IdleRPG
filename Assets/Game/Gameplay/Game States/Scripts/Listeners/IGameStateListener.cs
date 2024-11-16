namespace Game.Gameplay.GameStates
{
    public interface IGameStateListener
    {
        
    }

    public interface IGameStartListener : IGameStateListener
    {
        void OnStart();
    }

    public interface IGameFinishListener : IGameStateListener
    {
        void OnFinish();
    }

    public interface IGameInitializeListener : IGameStateListener
    {
        void OnInitialize();
    }

    public interface IGamePauseListener : IGameStateListener
    {
        void OnResume();
        void OnPause();
    }
}