using Game.App.Loading.Views;
using Zenject;

namespace Game.App.Loading
{
    public class AppBootstrap : IInitializable
    {
        private readonly GameLoader _gameLoader;
        private readonly GameLoadingView _gameLoadingView;

        public AppBootstrap(GameLoader gameLoader, GameLoadingView gameLoadingView)
        {
            _gameLoader = gameLoader;
            _gameLoadingView = gameLoadingView;
        }

        public void Initialize()
        {
            _gameLoadingView.Initialize(new GameLoadingViewPresenter(_gameLoader));
            _gameLoader.Load();
        }
    }
}