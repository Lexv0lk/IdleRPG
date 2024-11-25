using System;
using System.Collections.Generic;
using Game.Meta.Rewards;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Game.Meta.Quests
{
    public abstract class QuestConfig : SerializedScriptableObject
    {
        [OdinSerialize] private string _id;
        [OdinSerialize] private QuestMetadata _metadata;
        [OdinSerialize] private IReward[] _rewards = Array.Empty<IReward>();

        public string Id => _id;
        public QuestMetadata Metadata => _metadata;
        public IReadOnlyCollection<IReward> Rewards => _rewards;

        public abstract Quest InstantiateQuest();
    }
}