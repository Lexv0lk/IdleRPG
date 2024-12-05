using Game.GameEngine.DI;
using SaveSystem;

namespace Game.App.SaveSystem
{
    public interface ISaveLoader
    {
        void LoadState(GameRepository repository, GameContext context);

        void SaveState(GameRepository repository, GameContext context);
    }
}