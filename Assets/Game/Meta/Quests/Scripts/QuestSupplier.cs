using System.Collections.Generic;
using System.Linq;
using Game.Configs;

namespace Game.Meta.Quests
{
    public class QuestSupplier
    {
        private readonly QuestList _questList;
        private readonly QuestFactory _questFactory;
        private readonly Dictionary<string, QuestConfig> _questConfigs = new();
        
        public int NextQuestIndex { get; private set; } = 0;

        public QuestSupplier(ConfigService configService, QuestFactory questFactory)
        {
            _questList = configService.GetConfig<QuestList>();
            _questFactory = questFactory;

            foreach (var questConfig in _questList.QuestConfigs)
                _questConfigs[questConfig.Id] = questConfig;
        }

        public void SetupNextQuestIndex(int ind)
        {
            NextQuestIndex = ind;
        }

        public Quest GetNext()
        {
            if (NextQuestIndex >= _questList.QuestConfigs.Length)
                return null;
            
            return _questFactory.Instantiate(_questList.QuestConfigs[NextQuestIndex++]);
        }

        public Quest Get(string id)
        {
            return _questFactory.Instantiate(_questConfigs[id]);
        }

        public QuestConfig GetConfig(string id)
        {
            return _questConfigs[id];
        }
    }
}