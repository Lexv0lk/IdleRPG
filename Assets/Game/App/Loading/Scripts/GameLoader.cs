using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Game.App.Loading
{
    public class GameLoader
    {
        private readonly GameLoadingPipeline _pipeline;
        private readonly DiContainer _diContainer;

        public float CurrentProgress { get; private set; }
        public IGameLoadingTask CurrentTask { get; private set; }

        public event Action<float> ProgressChanged;
        public event Action<IGameLoadingTask> ActiveTaskChanged;
        public event Action Completed;

        public GameLoader(GameLoadingPipeline pipeline, DiContainer diContainer)
        {
            _pipeline = pipeline;
            _diContainer = diContainer;
        }

        public async UniTask Load()
        {
            for (int i = 0; i < _pipeline.LoadingTasks.Length; i++)
            {
                CurrentTask = _pipeline.LoadingTasks[i];
                CurrentProgress = (float)(i + 1) / _pipeline.LoadingTasks.Length;
                ProgressChanged?.Invoke(CurrentProgress);
                ActiveTaskChanged?.Invoke(CurrentTask);
                
                _diContainer.Inject(_pipeline.LoadingTasks[i]);
                await _pipeline.LoadingTasks[i].Do();
            }
            
            Completed?.Invoke();
        }
    }
}