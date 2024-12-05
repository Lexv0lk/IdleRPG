using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game.App.Loading
{
    [Serializable]
    public class GameSceneLoadingTask : IGameLoadingTask
    {
        [SerializeField, TextArea] private string _description;
        [SerializeField] private AssetReference _gameScene;

        public string Description => _description;
        
        public async UniTask<LoadingTaskResult> Do()
        {
            try
            {
                await Addressables.LoadSceneAsync(_gameScene, LoadSceneMode.Additive);
                return LoadingTaskResult.OK;
            }
            catch
            {
                return LoadingTaskResult.ERROR;
            }
        }
    }
}