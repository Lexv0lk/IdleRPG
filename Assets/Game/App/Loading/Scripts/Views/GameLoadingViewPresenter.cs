using UniRx;

namespace Game.App.Loading.Views
{
    public class GameLoadingViewPresenter
    {
        private readonly GameLoader _gameLoader;
        private readonly StringReactiveProperty _description;
        private readonly FloatReactiveProperty _progress;

        public IReadOnlyReactiveProperty<string> Description => _description;
        public IReadOnlyReactiveProperty<float> Progress => _progress;

        public GameLoadingViewPresenter(GameLoader gameLoader)
        {
            _gameLoader = gameLoader;
            _description = new StringReactiveProperty();
            _progress = new FloatReactiveProperty();
            
            _gameLoader.ProgressChanged += OnProgressChanged;
            _gameLoader.ActiveTaskChanged += OnTaskChanged;
        }

        private void OnTaskChanged(IGameLoadingTask task)
        {
            _description.Value = task.Description;
        }

        private void OnProgressChanged(float val)
        {
            _progress.Value = val;
        }
    }
}