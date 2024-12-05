using System;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.App.Loading
{
    [Serializable]
    public class LoadingSceneUnloadLoadingTask : IGameLoadingTask
    {
        [SerializeField, TextArea] private string _description;
        [SerializeField] private SceneAsset _scene;

        public string Description => _description;
        
        public async UniTask<LoadingTaskResult> Do()
        {
            await SceneManager.UnloadSceneAsync(_scene.name);
            return LoadingTaskResult.OK;
        }
    }
}