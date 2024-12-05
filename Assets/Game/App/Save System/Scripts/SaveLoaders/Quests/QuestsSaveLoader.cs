using Game.Meta.Quests;

namespace Game.App.SaveSystem
{
    public class QuestsSaveLoader : SaveLoader<QuestsSnapshot, QuestsManager>
    {
        protected override QuestsSnapshot GetSaveData(QuestsManager service)
        {
            return service.GetSnapshot();
        }

        protected override void SetSaveData(QuestsManager service, QuestsSnapshot data)
        {
            service.Setup(data);
        }

        protected override void SetDefaultData(QuestsManager service)
        {
            service.SetupStartQuests();
        }
    }
}