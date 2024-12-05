using Cysharp.Threading.Tasks;

namespace Game.App.Loading
{
    public interface IGameLoadingTask
    {
        public string Description { get; }
        UniTask<LoadingTaskResult> Do();
    }
}