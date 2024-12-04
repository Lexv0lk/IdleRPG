using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace Game.Gameplay.Quests
{
    public class QuestCatalogView : MonoBehaviour
    {
        private readonly Dictionary<QuestViewPresenter, QuestView> _questViews = new();

        [SerializeField] private QuestView _questViewPrefab;
        [SerializeField] private Transform _questsRoot;
        [SerializeField] private Button _closeButton;

        private QuestCatalogViewPresenter _presenter;
        private CompositeDisposable _compositeDisposable;
        private DiContainer _diContainer;
        
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void Initialize(QuestCatalogViewPresenter presenter)
        {
            DisposceCurrentPresenter();
            _presenter = presenter;
            _compositeDisposable = new CompositeDisposable();
            
            foreach (var questPresenter in presenter.QuestPresenters)
            {
                QuestView questView = _diContainer.InstantiatePrefabForComponent<QuestView>(_questViewPrefab, _questsRoot);
                questView.Initialize(questPresenter);
                _questViews.Add(questPresenter, questView);
            }

            presenter.QuestPresenters.ObserveReplace().Subscribe(OnQuestPresenterReplaced).AddTo(_compositeDisposable);
            presenter.QuestPresenters.ObserveRemove().Subscribe(OnQuestPresenterRemoved).AddTo(_compositeDisposable);
            presenter.QuestPresenters.ObserveAdd().Subscribe(OnQuestPresenterAdded).AddTo(_compositeDisposable);
        }

        private void OnQuestPresenterAdded(CollectionAddEvent<QuestViewPresenter> evt)
        {
            QuestView questView = _diContainer.InstantiatePrefabForComponent<QuestView>(_questViewPrefab, _questsRoot);
            questView.Initialize(evt.Value);
            _questViews[evt.Value] = questView;
        }

        private void OnQuestPresenterReplaced(CollectionReplaceEvent<QuestViewPresenter> evt)
        {
            var view = _questViews[evt.OldValue];
            _questViews.Remove(evt.OldValue);
            
            view.Initialize(evt.NewValue);
            _questViews[evt.NewValue] = view;
        }
        
        private void OnQuestPresenterRemoved(CollectionRemoveEvent<QuestViewPresenter> evt)
        {
            var view = _questViews[evt.Value];
            _questViews.Remove(evt.Value);
            Destroy(view.gameObject);
        }

        private void DisposceCurrentPresenter()
        {
            if (_presenter != null)
            {
                _compositeDisposable.Dispose();
                _presenter = null;
            }
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            DisposceCurrentPresenter();
        }
    }
}