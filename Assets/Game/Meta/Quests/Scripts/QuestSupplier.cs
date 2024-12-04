using Game.Configs;

namespace Game.Meta.Quests
{
    public class QuestSupplier
    {
        private readonly QuestList _questList;
        private readonly QuestFactory _questFactory;
        
        private int _currentIndex = 0;

        public QuestSupplier(ConfigService configService, QuestFactory questFactory)
        {
            _questList = configService.GetConfig<QuestList>();
            _questFactory = questFactory;
        }

        public Quest GetNext()
        {
            if (_currentIndex >= _questList.QuestConfigs.Length)
                return null;
            
            return _questFactory.Instantiate(_questList.QuestConfigs[_currentIndex++]);
        }
    }
}