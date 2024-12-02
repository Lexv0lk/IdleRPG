using Game.GameEngine.Resource;
using UniRx;
using UnityEngine;

namespace Game.Gameplay.Resource
{
    public class ResourceViewPresenter
    {
        private readonly ResourceConfig _resource;
        private readonly ResourcesStorage _storage;

        private ReactiveProperty<string> _resourceCount;

        public IReadOnlyReactiveProperty<string> ResourceCount => _resourceCount;
        public Sprite ResourceIcon { get; }

        public ResourceViewPresenter(ResourceConfig resource, ResourcesStorage storage)
        {
            _resource = resource;
            _storage = storage;

            ResourceIcon = _resource.Icon;
            _resourceCount = new ReactiveProperty<string>(storage.GetCount(_resource.Type).ToString());
            
            _storage.ResourceChanged += OnResourcesChanged;
        }

        private void OnResourcesChanged(ResourceType type, int newCount)
        {
            if (type != _resource.Type)
                return;

            _resourceCount.Value = newCount.ToString();
        }

        ~ResourceViewPresenter()
        {
            _storage.ResourceChanged -= OnResourcesChanged;
        }
    }
}