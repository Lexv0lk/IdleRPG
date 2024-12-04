using System;
using System.Collections.Generic;
using Game.Configs;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Meta.Quests
{
    [CreateAssetMenu(fileName = "Quest List", menuName = "Quests/List")]
    public class QuestList : SerializedScriptableObject, IConfig
    {
        [OdinSerialize] private QuestConfig[] _quests = Array.Empty<QuestConfig>();

        public QuestConfig[] QuestConfigs => _quests;
    }
}