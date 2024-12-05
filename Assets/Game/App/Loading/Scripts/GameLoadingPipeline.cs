using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.App.Loading
{
    [CreateAssetMenu(fileName = "Game Loading Pipeline", menuName = "Configs/Game Loading Pipeline")]
    public class GameLoadingPipeline : SerializedScriptableObject
    {
        [SerializeField] private IGameLoadingTask[] _loadingTasks;

        public IGameLoadingTask[] LoadingTasks => _loadingTasks;
    }
}