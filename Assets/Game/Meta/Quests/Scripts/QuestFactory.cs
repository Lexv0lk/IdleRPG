using Zenject;

namespace Game.Meta.Quests
{
    public class QuestFactory
    {
        private readonly DiContainer _diContainer;

        public QuestFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public Quest Instantiate(QuestConfig config)
        {
            Quest quest = config.InstantiateQuest();
            _diContainer.Inject(quest);
            return quest;
        }
    }
}