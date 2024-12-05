using System;
using Cysharp.Threading.Tasks;
using SaveSystem;
using UnityEngine;
using Zenject;

namespace Game.App.Loading
{
    [Serializable]
    public class SavesLoadingTask : IGameLoadingTask
    {
        [SerializeField, TextArea] private string _description;

        private GameRepository _gameRepository;

        public string Description => _description;

        [Inject]
        private void Construct(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public async UniTask<LoadingTaskResult> Do()
        {
            _gameRepository.LoadState();
            return LoadingTaskResult.OK;
        }
    }
}