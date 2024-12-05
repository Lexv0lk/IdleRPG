using System;

namespace Game.App.SaveSystem
{
    [Serializable]
    public struct QuestsSnapshot
    {
        public int NextQuestIndex;
        public QuestData[] QuestDatas;
    }

    [Serializable]
    public struct QuestData
    {
        public string Id;
        public string SerializedState;
    }
}