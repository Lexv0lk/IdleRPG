using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Meta.Quests
{
    [CreateAssetMenu(fileName = "Quest List", menuName = "Quests/List")]
    public class QuestList : SerializedScriptableObject
    {
        [OdinSerialize] private QuestConfig[] _quests = Array.Empty<QuestConfig>();
        [SerializeField] private bool _useRandom;

        private int _currentIndex;

        public QuestConfig GetNext()
        {
            if (_useRandom)
                return _quests[Random.Range(0, _quests.Length)];

            return _quests[_currentIndex++];
        }
    }
}