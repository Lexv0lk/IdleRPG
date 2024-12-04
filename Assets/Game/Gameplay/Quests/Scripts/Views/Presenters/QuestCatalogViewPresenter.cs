using System.Linq;
using Game.Meta.Quests;
using UniRx;

namespace Game.Gameplay.Quests
{
    public class QuestCatalogViewPresenter
    {
        private readonly QuestsManager _questsManager;
        private readonly ReactiveCollection<QuestViewPresenter> _questPresenters;
        private readonly CompositeDisposable _compositeDisposable;

        public IReadOnlyReactiveCollection<QuestViewPresenter> QuestPresenters => _questPresenters;

        public QuestCatalogViewPresenter(QuestsManager questsManager)
        {
            _compositeDisposable = new CompositeDisposable();
            _questsManager = questsManager;
            _questPresenters = new ReactiveCollection<QuestViewPresenter>(
                _questsManager.ActiveQuests.Select(q => new QuestViewPresenter(q, _questsManager)));

            _questsManager.ActiveQuests.ObserveReplace().Subscribe(OnQuestReplaced).AddTo(_compositeDisposable);
            _questsManager.ActiveQuests.ObserveRemove().Subscribe(OnQuestRemoved).AddTo(_compositeDisposable);
            _questsManager.ActiveQuests.ObserveAdd().Subscribe(OnQuestAdded).AddTo(_compositeDisposable);
        }

        private void OnQuestAdded(CollectionAddEvent<Quest> evt)
        {
            _questPresenters.Insert(evt.Index, new QuestViewPresenter(evt.Value, _questsManager));
        }

        private void OnQuestRemoved(CollectionRemoveEvent<Quest> evt)
        {
            _questPresenters.RemoveAt(evt.Index);
        }

        private void OnQuestReplaced(CollectionReplaceEvent<Quest> evt)
        {
            _questPresenters[evt.Index] = new QuestViewPresenter(evt.NewValue, _questsManager);
        }
        
        ~QuestCatalogViewPresenter()
        {
            _compositeDisposable.Dispose();
        }
    }
}